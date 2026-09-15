using Connected.Common.Types.Numbering.Incremental.Dtos;
using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;
using Connected.Threading;

namespace Connected.Common.Types.Numbering.Incremental.Ops;

internal sealed class Next(IStorageProvider storage, IEventService events, IIncrementalNumberService numbering,
    IIncrementalNumberNextAmbient ambient)
    : ServiceFunction<IIncrementalNumberDto, int>
{
    private static readonly AsyncLocker<string> _locker = new();

    protected override async Task<int> OnInvoke()
    {
        var key = Dto.Key;

        var entity = await _locker.LockAsync(key.ToLowerInvariant(), async () =>
        {
            /*
			 * An isolated connection commits the counter as soon as the statement completes instead of
			 * enlisting in the caller's transaction. Its row lock is therefore released while this lock is
			 * still held, so a reservation can never end up waiting on a batch which is itself waiting
			 * for this lock.
			 */
            var numbers = storage.Open<IncrementalNumber>(StorageConnectionMode.Isolated);
            /*
			 * Read straight from storage. A cached counter can be stale and would hand out a value
			 * another writer has already committed.
			 */
            var existing = await numbers.AsEntity(f => f.Key == key);

            CalculateNext(existing);

            if (existing is null)
            {
                return await numbers.Update(Dto.AsEntity<IncrementalNumber>(State.Add, ambient))
                    ?? throw new NullReferenceException(Strings.ErrEntityExpected);
            }

            return await numbers.Update(existing, current =>
            {
                return Task.FromResult(current.Merge(Dto, State.Update, ambient));
            }, async () =>
            {
                /*
				 * Someone committed between our read and our write. Re-read and recalculate from the row
				 * as it stands now, otherwise the retry would resubmit the value which just lost.
				 */
                var current = await numbers.AsEntity(f => f.Key == key)
                    ?? throw new NullReferenceException(Strings.ErrEntityExpected);

                CalculateNext(current);

                return current;
            }, Caller) ?? throw new NullReferenceException(Strings.ErrEntityExpected);
        });

        SetState(entity);

        await events.Updated(this, numbering, entity.Id);

        return entity.Value.GetValueOrDefault();
    }

    private void CalculateNext(IncrementalNumber? current)
    {
        var now = DateTimeOffset.UtcNow;

        ambient.Value = current is not null && current.TimeStamp.GetValueOrDefault().Year == now.Year
            ? current.Value.GetValueOrDefault() + 1
            : 1;

        ambient.TimeStamp = now;
    }
}

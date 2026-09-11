using Connected.Common.Types.Numbering.Incremental.Dtos;
using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;
using Connected.Threading;

namespace Connected.Common.Types.Numbering.Incremental.Ops;

internal sealed class Next(IStorageProvider storage, IEventService events, IIncrementalNumberService numbering,
	IIncrementalNumberCache cache, IIncrementalNumberNextAmbient ambient)
	: ServiceFunction<IIncrementalNumberDto, int>
{
	private static readonly AsyncLocker<string> _locker = new();

	protected override async Task<int> OnInvoke()
	{
		var key = Dto.Key.ToLowerInvariant();

		var entity = await _locker.LockAsync(key, async () =>
		{
			await ambient.Invoke(Dto);
			var existing = await cache.Get(f => string.Equals(f.Key, key, StringComparison.OrdinalIgnoreCase)) as IncrementalNumber;
			var numbers = storage.Open<IncrementalNumber>();

			// Commit the counter before releasing this lock. Keeping its SQL lock
			// until the event batch commits can deadlock the batch's next reservation.
			if (existing is null)
			{

				return await numbers.Update(Dto.AsEntity<IncrementalNumber>(State.Add, ambient))
					?? throw new NullReferenceException(Strings.ErrEntityExpected);
			}

			var result = await numbers.Update(existing, current =>
			{
				return Task.FromResult(current.Merge(Dto, State.Update, ambient));
			}, async () =>
			{
				var invalid = await cache.Get(f => string.Equals(f.Key, key, StringComparison.OrdinalIgnoreCase)) as IncrementalNumber;

				if (invalid != null)
					await cache.Refresh(invalid.Id);

				await ambient.Invoke(Dto);
				// Another process may have written since our read. The merge above
				// must calculate a new value from the current row on every retry.
				return (await cache.Get(f => string.Equals(f.Key, key, StringComparison.OrdinalIgnoreCase))).Required<IncrementalNumber>();

			}, Caller) ?? throw new NullReferenceException(Strings.ErrEntityExpected);

            SetState(result);

            await cache.Refresh(result.Id);
            await events.Updated(this, numbering, result.Id);

			return result;
        });

		return entity.Value.GetValueOrDefault();
	}
}

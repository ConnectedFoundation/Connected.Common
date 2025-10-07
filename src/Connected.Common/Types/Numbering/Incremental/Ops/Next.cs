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
	private static AsyncLocker<string> _locker;

	static Next()
	{
		_locker = new();
	}

	protected override async Task<int> OnInvoke()
	{
		IncrementalNumber? entity = null;

		await _locker.LockAsync(Dto.Key.ToLowerInvariant(), async () =>
		{
			entity = await numbering.Select(Dto) as IncrementalNumber;
			entity ??= await storage.Open<IncrementalNumber>().Update(Dto.AsEntity<IncrementalNumber>(State.Add, ambient)) ?? throw new NullReferenceException(Strings.ErrEntityExpected);

			SetState(entity);

			await storage.Open<IncrementalNumber>().Update(entity.Merge(Dto, State.Update, ambient), Dto, async () =>
			{
				await cache.Refresh(entity.Id);

				return SetState(await numbering.Select(Dto)) as IncrementalNumber ?? throw new NullReferenceException(Strings.ErrEntityExpected);
			}, Caller, async (f) =>
			{
				return await Task.FromResult(f.Merge(Dto, State.Update, ambient));
			});
		});

		if (entity is not null)
		{
			await cache.Refresh(entity.Id);
			await events.Updated(this, numbering, entity.Id);
		}

		return ambient.Value;
	}
}

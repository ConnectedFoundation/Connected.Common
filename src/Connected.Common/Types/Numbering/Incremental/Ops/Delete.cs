using Connected.Common.Types.Numbering.Incremental.Dtos;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Common.Types.Numbering.Incremental.Ops;
internal class Delete(IStorageProvider storage, IEventService events, IIncrementalNumberService numbering, IIncrementalNumberCache cache)
	: ServiceAction<IIncrementalNumberDto>
{
	protected override async Task OnInvoke()
	{
		var entity = SetState(await numbering.Select(Dto)) ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<IncrementalNumber>().Update(Dto.AsEntity<IncrementalNumber>(Entities.State.Delete));
		await cache.Remove(entity.Id);
		await events.Deleted(this, numbering, entity.Id);
	}
}

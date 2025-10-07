using Connected.Common.Types.Workplaces.Dtos;
using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Common.Types.Workplaces.Ops;

internal sealed class Insert(IWorkplaceService workplaces, IEventService events, IWorkplaceCache cache, IStorageProvider storage)
  : ServiceFunction<IInsertWorkplaceDto, int>
{
	protected override async Task<int> OnInvoke()
	{
		var entity = SetState(await storage.Open<Workplace>().Update(Dto.AsEntity<Workplace>(State.Add))) ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await cache.Refresh(entity.Id);
		await events.Deleted(this, workplaces, entity.Id);

		return entity.Id;
	}
}

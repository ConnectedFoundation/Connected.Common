using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Common.Types.Workplaces.Ops;

internal sealed class Delete(IWorkplaceService workplaces, IEventService events, IWorkplaceCache cache, IStorageProvider storage)
  : ServiceAction<IPrimaryKeyDto<int>>
{
	protected override async Task OnInvoke()
	{
		var entity = SetState(await workplaces.Select(Dto)) as Workplace ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<Workplace>().Update(entity.Merge(Dto, State.Delete));
		await cache.Remove(entity.Id);
		await events.Deleted(this, workplaces, Dto.Id);
	}
}

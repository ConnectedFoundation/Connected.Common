using Connected.Common.Types.Workplaces.Dtos;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Common.Types.Workplaces.Ops;

internal sealed class Update(IWorkplaceService workplaces, IEventService events, IWorkplaceCache cache, IStorageProvider storage)
  : ServiceAction<IUpdateWorkplaceDto>
{
	protected override async Task OnInvoke()
	{
		var entity = SetState(await workplaces.Select(Dto)) as Workplace ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<Workplace>().Update(entity.Merge(Dto, Entities.State.Update), Dto, async () =>
		{
			await cache.Refresh(entity.Id);

			return SetState(await workplaces.Select(Dto)) as Workplace ?? throw new NullReferenceException(Strings.ErrEntityExpected);
		}, Caller);

		await cache.Refresh(entity.Id);
		await events.Updated(this, workplaces, entity.Id);
	}
}

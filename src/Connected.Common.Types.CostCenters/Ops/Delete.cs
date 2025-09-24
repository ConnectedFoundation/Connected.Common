using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Common.Types.CostCenters.Ops;
internal sealed class Delete(IStorageProvider storage, IEventService events, ICostCenterCache cache, ICostCenterService centers)
	: ServiceAction<IPrimaryKeyDto<int>>
{

	protected override async Task OnInvoke()
	{
		_ = SetState(await centers.Select(Dto)) ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<CostCenter>().Update(Dto.AsEntity<CostCenter>(State.Delete));
		await cache.Refresh(Dto.Id);
		await events.Deleted(this, centers, Dto);
	}
}

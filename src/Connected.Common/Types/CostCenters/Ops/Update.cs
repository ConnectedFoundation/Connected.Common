using Connected.Common.Types.CostCenters.Dtos;
using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Common.Types.CostCenters.Ops;
internal sealed class Update(IStorageProvider storage, IEventService events, ICostCenterCache cache, ICostCenterService centers)
	: ServiceAction<IUpdateCostCenterDto>
{

	protected override async Task OnInvoke()
	{
		var existing = SetState(await centers.Select(Dto.AsDto<IPrimaryKeyDto<int>>()) as CostCenter) ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<CostCenter>().Update(Dto.AsEntity<CostCenter>(State.Update), Dto, async () =>
		{
			await cache.Refresh(Dto.Id);

			return SetState(await centers.Select(Dto.AsDto<IPrimaryKeyDto<int>>()) as CostCenter);
		}, Caller);

		await cache.Refresh(Dto.Id);
		await events.Updated(this, centers, Dto.Id);
	}
}

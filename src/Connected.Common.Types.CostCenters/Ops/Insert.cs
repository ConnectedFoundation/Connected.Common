using Connected.Common.Types.CostCenters.Dtos;
using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Common.Types.CostCenters.Ops;
internal sealed class Insert(IStorageProvider storage, IEventService events, ICostCenterCache cache, ICostCenterService centers)
	: ServiceFunction<IInsertCostCenterDto, int>
{

	protected override async Task<int> OnInvoke()
	{
		var entity = await storage.Open<CostCenter>().Update(Dto.AsEntity<CostCenter>(State.Add)) ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		SetState(entity);

		await cache.Refresh(entity.Id);
		await events.Inserted(this, centers, entity.Id);

		return entity.Id;
	}
}

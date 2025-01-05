using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Common.Types.MeasureUnits;
internal sealed class Delete(IStorageProvider storage, IEventService events, IMeasureUnitCache cache, IMeasureUnitService measureUnits)
	: ServiceAction<IPrimaryKeyDto<int>>
{

	protected override async Task OnInvoke()
	{
		SetState(await measureUnits.Select(Dto));

		await storage.Open<MeasureUnit>().Update(Dto.AsEntity<MeasureUnit>(State.Deleted));
		await cache.Refresh(Dto.Id);
		await events.Deleted(this, measureUnits, Dto);
	}
}

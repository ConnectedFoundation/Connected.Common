using Connected.Common.Types.MeasureUnits.Dtos;
using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Common.Types.MeasureUnits.Ops;
internal sealed class Insert(IStorageProvider storage, IEventService events, IMeasureUnitCache cache, IMeasureUnitService measureUnits)
	: ServiceFunction<IInsertMeasureUnitDto, int>
{

	protected override async Task<int> OnInvoke()
	{
		var entity = await storage.Open<MeasureUnit>().Update(Dto.AsEntity<MeasureUnit>(State.Add)) ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await cache.Refresh(entity.Id);
		await events.Inserted(this, measureUnits, entity.Id);

		return entity.Id;
	}
}

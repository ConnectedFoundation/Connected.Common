using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Common.Types.MeasureUnits;
internal sealed class Insert(IStorageProvider storage, IEventService events, IMeasureUnitCache cache, IMeasureUnitService measureUnits)
	: ServiceFunction<IInsertMeasureUnitDto, int>
{

	protected override async Task<int> OnInvoke()
	{
		var entity = await storage.Open<MeasureUnit>().Update(Dto.AsEntity<MeasureUnit>(State.New)) ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await cache.Refresh(entity.Id);
		await events.Inserted(this, measureUnits, entity.Id);

		return entity.Id;
	}
}

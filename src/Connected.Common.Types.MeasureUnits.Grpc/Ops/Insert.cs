using Connected.Common.Types.MeasureUnits.Dtos;
using Connected.Notifications;
using Connected.Services;

namespace Connected.Common.Types.MeasureUnits.Ops;
internal sealed class Insert(IEventService events, IMeasureUnitService measureUnits)
	: ServiceFunction<IInsertMeasureUnitDto, int>
{

	protected override Task<int> OnInvoke()
	{
		throw new NotImplementedException();
	}
}

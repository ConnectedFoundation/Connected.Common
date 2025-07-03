using Connected.Common.Types.MeasureUnits.Dtos;
using Connected.Services;

namespace Connected.Common.Types.MeasureUnits.Ops;
internal sealed class SelectByCode
	: ServiceFunction<ISelectMeasureUnitDto, IMeasureUnit?>
{

	protected override Task<IMeasureUnit?> OnInvoke()
	{
		throw new NotImplementedException();
	}
}

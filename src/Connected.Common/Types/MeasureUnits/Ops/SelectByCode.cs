using Connected.Common.Types.MeasureUnits.Dtos;
using Connected.Entities;
using Connected.Services;

namespace Connected.Common.Types.MeasureUnits.Ops;
internal sealed class SelectByCode(IMeasureUnitCache cache)
	: ServiceFunction<ISelectMeasureUnitDto, IMeasureUnit?>
{

	protected override async Task<IMeasureUnit?> OnInvoke()
	{
		return await cache.AsEntity(f => string.Equals(f.Code, Dto.Code, StringComparison.OrdinalIgnoreCase));
	}
}

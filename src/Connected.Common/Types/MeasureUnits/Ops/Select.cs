using Connected.Entities;
using Connected.Services;

namespace Connected.Common.Types.MeasureUnits.Ops;
internal sealed class Select(IMeasureUnitCache cache)
	: ServiceFunction<IPrimaryKeyDto<int>, IMeasureUnit?>
{

	protected override async Task<IMeasureUnit?> OnInvoke()
	{
		return await cache.AsEntity(f => f.Id == Dto.Id);
	}
}

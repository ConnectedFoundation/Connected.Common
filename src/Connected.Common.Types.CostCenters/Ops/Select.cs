using Connected.Entities;
using Connected.Services;

namespace Connected.Common.Types.CostCenters.Ops;
internal sealed class Select(ICostCenterCache cache)
	: ServiceFunction<IPrimaryKeyDto<int>, ICostCenter?>
{

	protected override async Task<ICostCenter?> OnInvoke()
	{
		return await cache.AsEntity(f => f.Id == Dto.Id);
	}
}

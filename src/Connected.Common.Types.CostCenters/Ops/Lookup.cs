using Connected.Entities;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Common.Types.CostCenters.Ops;
internal sealed class Lookup(ICostCenterCache cache)
	: ServiceFunction<IPrimaryKeyListDto<int>, IImmutableList<ICostCenter>>
{

	protected override async Task<IImmutableList<ICostCenter>> OnInvoke()
	{
		return await cache.AsEntities(f => Dto.Items.Any(g => g == f.Id));
	}
}

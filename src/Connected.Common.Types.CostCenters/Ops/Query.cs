using Connected.Entities;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Common.Types.CostCenters.Ops;
internal sealed class Query(ICostCenterCache cache)
	: ServiceFunction<IQueryDto, IImmutableList<ICostCenter>>
{

	protected override async Task<IImmutableList<ICostCenter>> OnInvoke()
	{
		return await cache.WithDto(Dto).AsEntities();
	}
}

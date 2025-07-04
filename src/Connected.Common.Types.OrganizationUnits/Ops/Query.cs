using Connected.Entities;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Common.Types.OrganizationUnits.Ops;

internal sealed class Query(IOrganizationUnitCache cache)
  : ServiceFunction<IQueryDto, IImmutableList<IOrganizationUnit>>
{
	protected override async Task<IImmutableList<IOrganizationUnit>> OnInvoke()
	{
		return await cache.WithDto(Dto).AsEntities<IOrganizationUnit>();
	}
}

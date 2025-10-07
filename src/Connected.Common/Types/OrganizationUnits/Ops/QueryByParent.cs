using Connected.Entities;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Common.Types.OrganizationUnits.Ops;

internal sealed class QueryByParent(IOrganizationUnitCache cache)
  : ServiceFunction<IParentDto<int?>, IImmutableList<IOrganizationUnit>>
{
	protected override async Task<IImmutableList<IOrganizationUnit>> OnInvoke()
	{
		return await cache.AsEntities<IOrganizationUnit>(f => Dto.Parent is null || f.Parent == Dto.Parent);
	}
}

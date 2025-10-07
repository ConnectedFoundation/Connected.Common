using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Common.Types.OrganizationUnits.Ops;

internal sealed class QueryByTags(IOrganizationUnitCache cache)
  : ServiceFunction<ITagListDto, IImmutableList<IOrganizationUnit>>
{
	protected override async Task<IImmutableList<IOrganizationUnit>> OnInvoke()
	{
		return (await cache.Query(Dto.Items)).ToImmutableList<IOrganizationUnit>();
	}
}

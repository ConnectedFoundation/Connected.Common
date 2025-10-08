using Connected.Entities;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Common.Types.OrganizationUnits.Membership.Ops;
internal sealed class Query(IOrganizationUnitMembershipCache cache)
	: ServiceFunction<IHeadDto<int>, IImmutableList<IOrganizationUnitMembership>>
{
	protected override async Task<IImmutableList<IOrganizationUnitMembership>> OnInvoke()
	{
		return await cache.AsEntities(f => f.Head == Dto.Head);
	}
}

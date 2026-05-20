using Connected.Entities;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Common.Types.OrganizationUnits.Membership.Ops;
internal sealed class Lookup(IOrganizationUnitMembershipCache cache)
	: ServiceFunction<IHeadListDto<int>, IImmutableList<IOrganizationUnitMembership>>
{
	protected override async Task<IImmutableList<IOrganizationUnitMembership>> OnInvoke()
	{
		return await cache.AsEntities(f => Dto.Items.Contains(f.Head));
	}
}

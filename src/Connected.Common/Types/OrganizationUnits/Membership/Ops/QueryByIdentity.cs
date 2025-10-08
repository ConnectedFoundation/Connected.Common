using Connected.Entities;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Common.Types.OrganizationUnits.Membership.Ops;
internal sealed class QueryByIdentity(IOrganizationUnitMembershipCache cache)
	: ServiceFunction<IValueDto<string>, IImmutableList<IOrganizationUnitMembership>>
{
	protected override async Task<IImmutableList<IOrganizationUnitMembership>> OnInvoke()
	{
		return await cache.AsEntities(f => string.Equals(f.Identity, Dto.Value, StringComparison.OrdinalIgnoreCase));
	}
}

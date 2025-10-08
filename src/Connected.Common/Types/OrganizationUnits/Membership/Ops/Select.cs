using Connected.Entities;
using Connected.Services;

namespace Connected.Common.Types.OrganizationUnits.Membership.Ops;
internal sealed class Select(IOrganizationUnitMembershipCache cache)
	: ServiceFunction<IPrimaryKeyDto<int>, IOrganizationUnitMembership?>
{
	protected override async Task<IOrganizationUnitMembership?> OnInvoke()
	{
		return await cache.AsEntity(f => f.Id == Dto.Id);
	}
}

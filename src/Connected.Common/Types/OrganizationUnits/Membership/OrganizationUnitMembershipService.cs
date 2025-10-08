using Connected.Common.Types.OrganizationUnits.Membership.Dtos;
using Connected.Common.Types.OrganizationUnits.Membership.Ops;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Common.Types.OrganizationUnits.Membership;
internal sealed class OrganizationUnitMembershipService(IServiceProvider services)
		: Service(services), IOrganizationUnitMembershipService
{
	public async Task Delete(IPrimaryKeyDto<int> dto)
	{
		await Invoke(GetOperation<Delete>(), dto);
	}

	public async Task<int> Insert(IInsertOrganizationUnitMembershipDto dto)
	{
		return await Invoke(GetOperation<Insert>(), dto);
	}

	public async Task<IImmutableList<IOrganizationUnitMembership>> Query(IHeadDto<int> dto)
	{
		return await Invoke(GetOperation<Query>(), dto);
	}

	public async Task<IImmutableList<IOrganizationUnitMembership>> Query(IValueDto<string> dto)
	{
		return await Invoke(GetOperation<QueryByIdentity>(), dto);
	}

	public async Task<IOrganizationUnitMembership?> Select(IPrimaryKeyDto<int> dto)
	{
		return await Invoke(GetOperation<Select>(), dto);
	}
}

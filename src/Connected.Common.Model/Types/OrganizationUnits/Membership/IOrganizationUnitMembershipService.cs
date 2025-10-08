using Connected.Annotations;
using Connected.Common.Types.OrganizationUnits.Membership.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Common.Types.OrganizationUnits.Membership;

[Service, ServiceUrl(CommonUrls.OrganizationUnitMembership)]
public interface IOrganizationUnitMembershipService
{
	[ServiceOperation(ServiceOperationVerbs.Post)]
	Task<int> Insert(IInsertOrganizationUnitMembershipDto dto);

	[ServiceOperation(ServiceOperationVerbs.Delete)]
	Task Delete(IPrimaryKeyDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Get)]
	Task<IImmutableList<IOrganizationUnitMembership>> Query(IHeadDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Get)]
	[ServiceUrl(ServiceOperations.QueryByIdentity)]
	Task<IImmutableList<IOrganizationUnitMembership>> Query(IValueDto<string> dto);

	[ServiceOperation(ServiceOperationVerbs.Get)]
	Task<IOrganizationUnitMembership?> Select(IPrimaryKeyDto<int> dto);
}

using Connected.Annotations;
using Connected.Common.Types.OrganizationUnits.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Common.Types.OrganizationUnits;

[Service, ServiceUrl(CommonTypesUrls.OrganizationUnits)]
public interface IOrganizationUnitService
{
	[ServiceOperation(ServiceOperationVerbs.Put)]
	Task<int> Insert(IInsertOrganizationUnitDto dto);

	[ServiceOperation(ServiceOperationVerbs.Post)]
	Task Update(IUpdateOrganizationUnitDto dto);

	[ServiceOperation(ServiceOperationVerbs.Patch)]
	Task Patch(IPatchDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Delete)]
	Task Delete(IPrimaryKeyDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Get)]
	Task<IOrganizationUnit?> Select(IPrimaryKeyDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Get)]
	Task<IImmutableList<IOrganizationUnit>> Query(IQueryDto? dto);

	[ServiceOperation(ServiceOperationVerbs.Get), ServiceUrl(CommonTypesUrls.QueryByParentOperation)]
	Task<IImmutableList<IOrganizationUnit>> Query(IParentDto<int?> dto);

	[ServiceOperation(ServiceOperationVerbs.Get), ServiceUrl(CommonTypesUrls.QueryByTagsOperation)]
	Task<IImmutableList<IOrganizationUnit>> Query(ITagListDto dto);
}

using Connected.Annotations;
using Connected.Common.Types.EnvironmentLocations.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Common.Types.EnvironmentLocations;

[Service, ServiceUrl(CommonTypesUrls.OrganizationUnits)]
public interface IEnvironmentLocationService
{
	[ServiceOperation(ServiceOperationVerbs.Put)]
	Task<int> Insert(IInsertEnvironmentLocationDto dto);

	[ServiceOperation(ServiceOperationVerbs.Post)]
	Task Update(IUpdateEnvironmentLocationDto dto);

	[ServiceOperation(ServiceOperationVerbs.Patch)]
	Task Patch(IPatchDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Delete)]
	Task Delete(IPrimaryKeyDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Get)]
	Task<IEnvironmentLocation?> Select(IPrimaryKeyDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Get)]
	Task<IImmutableList<IEnvironmentLocation>> Query(IQueryDto? dto);

	[ServiceOperation(ServiceOperationVerbs.Get), ServiceUrl(CommonTypesUrls.QueryByTagsOperation)]
	Task<IImmutableList<IEnvironmentLocation>> Query(ITagListDto dto);

	[ServiceOperation(ServiceOperationVerbs.Get), ServiceUrl(CommonTypesUrls.QueryByHeadOperation)]
	Task<IImmutableList<IEnvironmentLocation>> Query(IHeadDto<int> dto);
}

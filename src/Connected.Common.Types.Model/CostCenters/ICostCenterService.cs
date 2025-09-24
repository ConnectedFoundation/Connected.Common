using Connected.Annotations;
using Connected.Common.Types.CostCenters.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Common.Types.CostCenters;

[Service, ServiceUrl(CommonTypesUrls.CostCenters)]
public interface ICostCenterService
{
	[ServiceOperation(ServiceOperationVerbs.Post)]
	Task<int> Insert(IInsertCostCenterDto dto);

	[ServiceOperation(ServiceOperationVerbs.Put)]
	Task Update(IUpdateCostCenterDto dto);

	[ServiceOperation(ServiceOperationVerbs.Delete)]
	Task Delete(IPrimaryKeyDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Get)]
	Task<IImmutableList<ICostCenter>> Query(IQueryDto? dto);

	[ServiceOperation(ServiceOperationVerbs.Get), ServiceUrl(CommonTypesUrls.LookupOperation)]
	Task<IImmutableList<ICostCenter>> Query(IPrimaryKeyListDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Get)]
	Task<ICostCenter?> Select(IPrimaryKeyDto<int> dto);
}

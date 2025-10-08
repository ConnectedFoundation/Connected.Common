using Connected.Annotations;
using Connected.Common.Types.Workplaces.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Common.Types.Workplaces;

[Service, ServiceUrl(CommonUrls.Workplaces)]
public interface IWorkplaceService
{
	[ServiceOperation(ServiceOperationVerbs.Put)]
	Task<int> Insert(IInsertWorkplaceDto dto);

	[ServiceOperation(ServiceOperationVerbs.Post)]
	Task Update(IUpdateWorkplaceDto dto);

	[ServiceOperation(ServiceOperationVerbs.Patch)]
	Task Patch(IPatchDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Delete)]
	Task Delete(IPrimaryKeyDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Get)]
	Task<IImmutableList<IWorkplace>> Query(IQueryDto? dto);

	[ServiceOperation(ServiceOperationVerbs.Get), ServiceUrl(ServiceOperations.QueryByTags)]
	Task<IImmutableList<IWorkplace>> Query(ITagListDto dto);
	Task<IWorkplace?> Select(IPrimaryKeyDto<int> dto);
}

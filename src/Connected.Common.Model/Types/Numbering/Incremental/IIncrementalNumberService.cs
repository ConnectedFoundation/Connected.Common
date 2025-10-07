using Connected.Annotations;
using Connected.Common.Types.Numbering.Incremental.Dtos;

namespace Connected.Common.Types.Numbering.Incremental;

[Service, ServiceUrl(CommonTypesUrls.IncrementalNumbering)]
public interface IIncrementalNumberService
{
	[ServiceOperation(ServiceOperationVerbs.Delete)]
	Task Delete(IIncrementalNumberDto dto);

	[ServiceOperation(ServiceOperationVerbs.Put)]
	Task<int> Next(IIncrementalNumberDto dto);

	[ServiceOperation(ServiceOperationVerbs.Get)]
	Task<IIncrementalNumber?> Select(IIncrementalNumberDto dto);
}

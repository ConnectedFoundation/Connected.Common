using Connected.Annotations;
using Connected.Common.Types.Numbering.Incremental.Dtos;

namespace Connected.Common.Types.Numbering.Incremental;

[Service, ServiceUrl(CommonTypesUrls.IncrementalNumbering)]
public interface IIncrementalNumberService
{
	Task Delete(IIncrementalNumberDto dto);
	Task<string> Next(IIncrementalNumberDto dto);
	Task<IIncrementalNumber> Select(IIncrementalNumberDto dto);
}

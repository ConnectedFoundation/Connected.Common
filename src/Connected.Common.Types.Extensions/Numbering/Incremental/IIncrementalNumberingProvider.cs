using Connected.Common.Types.Extensions.Numbering.Incremental.Dtos;

namespace Connected.Common.Types.Extensions.Numbering.Incremental;
public interface IIncrementalNumberingProvider : IMiddleware
{
	Task<string?> Invoke(IIncrementalNumberingProviderDto dto);
}

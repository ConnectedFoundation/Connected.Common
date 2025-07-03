using Connected.Common.Types.Numbering.Incremental;
using Connected.Services;

namespace Connected.Common.Types.Extensions.Numbering.Incremental.Dtos;
public interface IIncrementalNumberingProviderDto : IDto
{
	IIncrementalNumber Entity { get; set; }
}

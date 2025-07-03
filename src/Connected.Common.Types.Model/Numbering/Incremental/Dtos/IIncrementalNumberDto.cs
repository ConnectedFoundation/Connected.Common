using Connected.Services;

namespace Connected.Common.Types.Numbering.Incremental.Dtos;
public interface IIncrementalNumberDto : IDto
{
	string Key { get; set; }
}

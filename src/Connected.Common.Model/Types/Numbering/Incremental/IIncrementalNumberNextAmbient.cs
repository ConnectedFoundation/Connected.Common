using Connected.Common.Types.Numbering.Incremental.Dtos;
using Connected.Services;

namespace Connected.Common.Types.Numbering.Incremental;
public interface IIncrementalNumberNextAmbient
	: IAmbientProvider<IIncrementalNumberDto>
{
	int Value { get; set; }
	DateTimeOffset TimeStamp { get; set; }
}

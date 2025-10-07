using Connected.Common.Types.Numbering.Incremental.Dtos;
using Connected.Services;

namespace Connected.Common.Types.Numbering.Incremental;
internal sealed class IncrementalNumberNextAmbient
	: AmbientProvider<IIncrementalNumberDto>, IIncrementalNumberNextAmbient
{
	public int Value { get; set; }
	public DateTimeOffset TimeStamp { get; set; } = DateTimeOffset.UtcNow;
}

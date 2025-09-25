using Connected.Services;
using System.ComponentModel.DataAnnotations;

namespace Connected.Common.Types.Numbering.Incremental.Dtos;
internal sealed class IncrementalNumberDto : Dto, IIncrementalNumberDto
{
	[Required, MaxLength(DefaultNameLength)]
	public required string Key { get; set; }
}

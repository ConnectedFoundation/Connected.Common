using Connected.Annotations;
using Connected.Entities;
using Connected.Services;
using System.ComponentModel.DataAnnotations;

namespace Connected.Common.Types.MeasureUnits.Dtos;
internal sealed class UpdateMeasureUnitDto : Dto, IUpdateMeasureUnitDto
{
	[MinValue(1)]
	public int Id { get; set; }

	[Required, MaxLength(32)]
	public required string Name { get; set; }

	[Required, MaxLength(8)]
	public required string Code { get; set; }

	[MinValue(0)]
	public byte Precision { get; set; }

	public Status Status { get; set; } = Status.Disabled;
}

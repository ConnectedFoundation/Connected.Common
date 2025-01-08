using Connected.Services;
using System.ComponentModel.DataAnnotations;

namespace Connected.Common.Types.MeasureUnits;
internal sealed class SelectMeasureUnitDto : Dto, ISelectMeasureUnitDto
{
	[Required, MaxLength(8)]
	public required string Code { get; set; }
}

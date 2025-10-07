using Connected.Entities;
using Connected.Services;
using System.ComponentModel.DataAnnotations;

namespace Connected.Common.Types.CostCenters.Dtos;
internal abstract class CostCenterDto : Dto, ICostCenterDto
{
	[Required, MaxLength(DefaultNameLength)]
	public required string Name { get; set; }

	[Required, MaxLength(DefaultCodeLength)]
	public required string Code { get; set; }

	public Status Status { get; set; }
}

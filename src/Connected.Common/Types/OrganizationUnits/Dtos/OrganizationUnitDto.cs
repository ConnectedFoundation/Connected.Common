using Connected.Entities;
using Connected.Services;
using System.ComponentModel.DataAnnotations;

namespace Connected.Common.Types.OrganizationUnits.Dtos;

internal abstract class OrganizationUnitDto : Dto, IOrganizationUnitDto
{
	[Required, MaxLength(DefaultNameLength)]
	public required string Name { get; set; }

	[Required, MaxLength(DefaultCodeLength)]
	public required string Code { get; set; }

	public int? Parent { get; set; }

	[MaxLength(1024)]
	public string? Tags { get; set; }

	public Status Status { get; set; } = Status.Disabled;
}

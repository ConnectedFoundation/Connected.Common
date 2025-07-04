using Connected.Entities;
using Connected.Services;
using System.ComponentModel.DataAnnotations;

namespace Connected.Common.Types.Workplaces.Dtos;

internal abstract class WorkplaceDto : Dto, IWorkplaceDto
{
	[Required, MaxLength(DefaultNameLength)]
	public required string Name { get; set; }

	[Required, MaxLength(DefaultCodeLength)]
	public required string Code { get; set; }

	[MaxLength(DefaultTagsLength)]
	public string? Tags { get; set; }

	public Status Status { get; set; } = Status.Disabled;
	public int? OrganizationUnit { get; set; }
	public int? OrganizationLocation { get; set; }
}

using Connected.Entities;
using Connected.Services;
using System.ComponentModel.DataAnnotations;

namespace Connected.Common.Types.EnvironmentLocations.Dtos;

internal abstract class EnvironmentLocationDto : Dto, IEnvironmentLocationDto
{
	[Required, MaxLength(DefaultNameLength)]
	public required string Name { get; set; }

	[Required, MaxLength(DefaultCodeLength)]
	public required string Code { get; set; }

	[MaxLength(DefaultTagsLength)]
	public string? Tags { get; set; }

	public Status Status { get; set; } = Status.Disabled;
	public int Head { get; set; }
}

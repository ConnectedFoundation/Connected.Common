using Connected.Annotations;

namespace Connected.Common.Types.EnvironmentLocations.Dtos;

internal sealed class UpdateEnvironmaneLocationDto : EnvironmentLocationDto, IUpdateEnvironmentLocationDto
{
	[MinValue(1)]
	public int Id { get; set; }
}

using Connected.Entities;
using Connected.Services;

namespace Connected.Common.Types.EnvironmentLocations.Dtos;

public interface IEnvironmentLocationDto : IDto
{
	string Name { get; set; }
	string Code { get; set; }
	int Head { get; set; }
	string? Tags { get; set; }
	Status Status { get; set; }
}

using Connected.Entities;

namespace Connected.Common.Types.EnvironmentLocations;

public interface IEnvironmentLocation : ITaggedEntity<int>
{
	string Name { get; init; }
	string Code { get; init; }
	int Head { get; init; }
	Status Status { get; init; }
}

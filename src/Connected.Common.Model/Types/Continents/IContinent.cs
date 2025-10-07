using Connected.Entities;

namespace Connected.Common.Types.Continents;
public interface IContinent : IEntity<int>
{
	string Name { get; init; }
	Status Status { get; init; }
}

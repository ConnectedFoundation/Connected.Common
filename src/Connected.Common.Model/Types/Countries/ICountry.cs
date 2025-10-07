using Connected.Entities;

namespace Connected.Common.Types.Countries;
public interface ICountry : IEntity<int>
{
	int Continent { get; init; }
	string Name { get; init; }
	Status Status { get; init; }
}

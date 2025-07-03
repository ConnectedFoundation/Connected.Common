using Connected.Entities;

namespace Connected.Common.Types.CountryStates;
public interface ICountryState : IEntity<int>
{
	int Country { get; init; }
	string Name { get; init; }
	Status Status { get; init; }
}

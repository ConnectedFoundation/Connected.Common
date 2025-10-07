using Connected.Entities;

namespace Connected.Common.Types.Addresses;
public interface IAddress : IEntity<int>
{
	int City { get; init; }
	string? Street { get; init; }
	string? Number { get; init; }
	string Floor { get; init; }
	string Unit { get; init; }
	Status Status { get; init; }
}

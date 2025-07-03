using Connected.Entities;

namespace Connected.Common.Types.Cities;
public interface ICity : IEntity<int>
{
	int Country { get; init; }
	int? PostalCode { get; init; }
	string Name { get; init; }
	Status Status { get; init; }
}

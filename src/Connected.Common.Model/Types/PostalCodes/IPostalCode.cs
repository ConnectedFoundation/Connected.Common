using Connected.Entities;

namespace Connected.Common.Types.PostalCodes;
public interface IPostalCode : IEntity<int>
{
	int Country { get; init; }
	int? CountryState { get; init; }
	string Name { get; init; }
	string Code { get; init; }
	Status Status { get; init; }
}

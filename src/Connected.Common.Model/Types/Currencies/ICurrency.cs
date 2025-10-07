using Connected.Entities;

namespace Connected.Common.Types.Currencies;
public interface ICurrency : IEntity<int>
{
	string Name { get; init; }
	string Symbol { get; init; }
	Status Status { get; init; }
}

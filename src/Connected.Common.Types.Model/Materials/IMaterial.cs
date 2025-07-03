using Connected.Entities;

namespace Connected.Common.Types.Materials;
public interface IMaterial : IEntity<long>
{
	string Code { get; init; }
	string Name { get; init; }
	int MeasureUnit { get; init; }
	string? Tags { get; init; }
	string? Description { get; init; }
}

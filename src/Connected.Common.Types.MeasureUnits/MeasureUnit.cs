using Connected.Annotations;
using Connected.Annotations.Entities;
using Connected.Entities;

namespace Connected.Common.Types.MeasureUnits;
internal sealed record MeasureUnit : ConsistentEntity<int>, IMeasureUnit
{
	[Ordinal(0), Length(32)]
	public required string Name { get; init; }

	[Ordinal(1), Length(8)]
	public required string Code { get; init; }

	[Ordinal(2)]
	public byte Precision { get; init; }

	[Ordinal(3)]
	public Status Status { get; init; }
}

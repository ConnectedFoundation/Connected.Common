using Connected.Entities;

namespace Connected.Common.Types.MeasureUnits;
internal sealed record MeasureUnit : Entity<int>, IMeasureUnit
{
	public required string Name { get; init; }
	public required string Code { get; init; }
	public byte Precision { get; init; }
	public Status Status { get; init; }
}

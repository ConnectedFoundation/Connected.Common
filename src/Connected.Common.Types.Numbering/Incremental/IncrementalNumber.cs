using Connected.Annotations;
using Connected.Annotations.Entities;
using Connected.Entities;
using Connected.Services;

namespace Connected.Common.Types.Numbering.Incremental;

[Table(Schema = SchemaAttribute.CommonSchema)]
internal sealed record IncrementalNumber : ConsistentEntity<int>, IIncrementalNumber
{
	[Ordinal(0), Length(Dto.DefaultNameLength)]
	public required string Key { get; init; }

	[Ordinal(1)]
	public int? Value { get; init; }

	[Ordinal(2), Date(DateKind.DateTime2, 7)]
	public DateTimeOffset? TimeStamp { get; init; }
}

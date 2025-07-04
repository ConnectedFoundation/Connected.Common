using Connected.Annotations;
using Connected.Annotations.Entities;
using Connected.Entities;
using Connected.Services;

namespace Connected.Common.Types.OrganizationUnits;

[Table(Schema = SchemaAttribute.CommonSchema)]
internal sealed record OrganizationUnit : ConsistentEntity<int>, IOrganizationUnit
{
	[Ordinal(0), Length(Dto.DefaultNameLength)]
	public required string Name { get; init; }

	[Ordinal(1), Length(Dto.DefaultCodeLength)]
	public required string Code { get; init; }

	[Ordinal(2)]
	public int? Parent { get; init; }

	[Ordinal(3)]
	public Status Status { get; init; }

	[Ordinal(4), Length(1024)]
	public string? Tags { get; init; }
}

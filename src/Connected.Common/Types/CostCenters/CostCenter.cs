using Connected.Annotations;
using Connected.Annotations.Entities;
using Connected.Entities;
using Connected.Services;
using System.ComponentModel.DataAnnotations;

namespace Connected.Common.Types.CostCenters;

[Table(Schema = SchemaAttribute.CommonSchema)]
internal sealed record CostCenter : ConsistentEntity<int>, ICostCenter
{
	[Ordinal(0), MaxLength(Dto.DefaultNameLength)]
	public required string Name { get; init; }

	[Ordinal(1), MaxLength(Dto.DefaultCodeLength)]
	public required string Code { get; init; }

	[Ordinal(2)]
	public Status Status { get; init; }
}

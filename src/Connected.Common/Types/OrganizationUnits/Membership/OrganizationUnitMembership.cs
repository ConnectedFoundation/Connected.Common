using Connected.Annotations;
using Connected.Annotations.Entities;
using Connected.Entities;
using Connected.Services;

namespace Connected.Common.Types.OrganizationUnits.Membership;

[Table(Schema = SchemaAttribute.CommonSchema)]
internal sealed record OrganizationUnitMembership
	: Entity<int>, IOrganizationUnitMembership
{
	[Ordinal(0)]
	public int Head { get; init; }

	[Ordinal(1), Length(Dto.DefaultIdentityLength)]
	public required string Identity { get; init; }
}

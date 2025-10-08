using Connected.Annotations;
using Connected.Services;
using System.ComponentModel.DataAnnotations;

namespace Connected.Common.Types.OrganizationUnits.Membership.Dtos;
internal sealed class InsertOrganizationUnitMembershipDto
	: Dto, IInsertOrganizationUnitMembershipDto
{
	[MinValue(1)]
	public int Head { get; set; }

	[Required, MaxLength(DefaultIdentityLength)]
	public required string Identity { get; set; }
}

using Connected.Services;

namespace Connected.Common.Types.OrganizationUnits.Membership.Dtos;
public interface IInsertOrganizationUnitMembershipDto
	: IDto
{
	int Head { get; set; }
	string Identity { get; set; }
}

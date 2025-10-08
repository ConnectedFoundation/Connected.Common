using Connected.Annotations.Entities;
using Connected.Entities;

namespace Connected.Common.Types.OrganizationUnits.Membership;

[EntityKey(CommonMetaData.OrganizationUnitMembershipKey)]
public interface IOrganizationUnitMembership
	: IEntity<int>
{
	int Head { get; init; }
	string Identity { get; init; }
}

using Connected.Caching;
using Connected.Storage;

namespace Connected.Common.Types.OrganizationUnits.Membership;
internal sealed class OrganizationUnitMembershipCache(ICachingService cache, IStorageProvider storage)
		: EntityCache<IOrganizationUnitMembership, OrganizationUnitMembership, int>(cache, storage, CommonMetaData.OrganizationUnitMembershipKey), IOrganizationUnitMembershipCache
{
}

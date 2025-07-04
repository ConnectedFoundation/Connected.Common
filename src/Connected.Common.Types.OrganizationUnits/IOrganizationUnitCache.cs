using Connected.Caching;
using System.Collections.Immutable;

namespace Connected.Common.Types.OrganizationUnits;

internal interface IOrganizationUnitCache
	: IEntityCache<OrganizationUnit, int>
{
	Task<IImmutableList<OrganizationUnit>> Query(List<string> tags);
}

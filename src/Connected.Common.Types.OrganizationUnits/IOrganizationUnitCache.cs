using Connected.Caching;
using System.Collections.Immutable;

namespace Connected.Common.Types.OrganizationUnits;

internal interface IOrganizationUnitCache
	: IEntityCache<IOrganizationUnit, int>
{
	Task<IImmutableList<IOrganizationUnit>> Query(List<string> tags);
}

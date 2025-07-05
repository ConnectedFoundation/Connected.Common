using Connected.Caching;
using System.Collections.Immutable;

namespace Connected.Common.Types.EnvironmentLocations;

internal interface IEnvironmentLocationCache
	: IEntityCache<EnvironmentLocation, int>
{
	Task<IImmutableList<EnvironmentLocation>> Query(List<string> tags);
}

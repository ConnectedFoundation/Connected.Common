using Connected.Caching;
using System.Collections.Immutable;

namespace Connected.Common.Types.EnvironmentLocations;

internal interface IEnvironmentLocationCache
	: IEntityCache<IEnvironmentLocation, int>
{
	Task<IImmutableList<IEnvironmentLocation>> Query(List<string> tags);
}

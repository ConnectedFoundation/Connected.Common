using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Common.Types.EnvironmentLocations.Ops;

internal sealed class QueryByTags(IEnvironmentLocationCache cache)
  : ServiceFunction<ITagListDto, IImmutableList<IEnvironmentLocation>>
{
	protected override async Task<IImmutableList<IEnvironmentLocation>> OnInvoke()
	{
		return (await cache.Query(Dto.Items)).ToImmutableList<IEnvironmentLocation>();
	}
}

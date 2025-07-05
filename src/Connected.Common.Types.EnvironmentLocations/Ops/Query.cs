using Connected.Entities;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Common.Types.EnvironmentLocations.Ops;

internal sealed class Query(IEnvironmentLocationCache cache)
  : ServiceFunction<IQueryDto, IImmutableList<IEnvironmentLocation>>
{
	protected override async Task<IImmutableList<IEnvironmentLocation>> OnInvoke()
	{
		return await cache.WithDto(Dto).AsEntities<IEnvironmentLocation>();
	}
}

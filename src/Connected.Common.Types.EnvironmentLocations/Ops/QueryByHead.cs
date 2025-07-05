using Connected.Entities;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Common.Types.EnvironmentLocations.Ops;

internal sealed class QueryByHead(IEnvironmentLocationCache cache)
  : ServiceFunction<IHeadDto<int>, IImmutableList<IEnvironmentLocation>>
{
	protected override async Task<IImmutableList<IEnvironmentLocation>> OnInvoke()
	{
		return await cache.AsEntities<IEnvironmentLocation>(f => f.Head == Dto.Head);
	}
}

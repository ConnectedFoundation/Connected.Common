using Connected.Entities;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Common.Types.Workplaces.Ops;

internal sealed class Query(IWorkplaceCache cache)
  : ServiceFunction<IQueryDto, IImmutableList<IWorkplace>>
{
	protected override async Task<IImmutableList<IWorkplace>> OnInvoke()
	{
		return await cache.WithDto(Dto).AsEntities<IWorkplace>();
	}
}

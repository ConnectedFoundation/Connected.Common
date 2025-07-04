using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Common.Types.Workplaces.Ops;

internal sealed class QueryByTags(IWorkplaceCache cache)
  : ServiceFunction<ITagListDto, IImmutableList<IWorkplace>>
{
	protected override async Task<IImmutableList<IWorkplace>> OnInvoke()
	{
		return (await cache.Query(Dto.Items)).ToImmutableList<IWorkplace>();
	}
}

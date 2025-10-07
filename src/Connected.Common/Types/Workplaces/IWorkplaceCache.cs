using Connected.Caching;
using System.Collections.Immutable;

namespace Connected.Common.Types.Workplaces;

internal interface IWorkplaceCache
	: IEntityCache<IWorkplace, int>
{
	Task<IImmutableList<IWorkplace>> Query(List<string> tags);
}

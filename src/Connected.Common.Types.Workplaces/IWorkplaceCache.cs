using Connected.Caching;
using System.Collections.Immutable;

namespace Connected.Common.Types.Workplaces;

internal interface IWorkplaceCache
	: IEntityCache<Workplace, int>
{
	Task<IImmutableList<Workplace>> Query(List<string> tags);
}

using Connected.Caching;

namespace Connected.Common.Types.Numbering.Incremental;
internal interface IIncrementalNumberCache
	: IEntityCache<IIncrementalNumber, int>
{
}

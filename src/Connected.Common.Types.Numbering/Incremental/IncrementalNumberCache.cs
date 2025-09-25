using Connected.Caching;
using Connected.Storage;

namespace Connected.Common.Types.Numbering.Incremental;
internal sealed class IncrementalNumberCache(ICachingService cache, IStorageProvider storage)
		: EntityCache<IIncrementalNumber, IncrementalNumber, int>(cache, storage, CommonTypesMetaData.IncrementalNumberKey), IIncrementalNumberCache
{
}

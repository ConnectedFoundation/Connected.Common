using Connected.Caching;
using Connected.Storage;

namespace Connected.Common.Types.MeasureUnits;
internal sealed class MeasureUnitCache(ICachingService cache, IStorageProvider storage)
	: EntityCache<IMeasureUnit, MeasureUnit, int>(cache, storage, CommonMetaData.MeasureUnitKey), IMeasureUnitCache
{
}

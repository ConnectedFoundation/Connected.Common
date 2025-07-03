using Connected.Caching;
using Connected.Storage;

namespace Connected.Common.Types.MeasureUnits;
internal sealed class MeasureUnitCache(ICachingService cache, IStorageProvider storage)
	: EntityCache<MeasureUnit, int>(cache, storage, CommonTypesMetaData.MeasureUnitKey), IMeasureUnitCache
{
}

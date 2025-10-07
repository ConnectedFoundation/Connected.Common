using Connected.Caching;
using Connected.Storage;

namespace Connected.Common.Types.CostCenters;
internal sealed class CostCenterCache(ICachingService cache, IStorageProvider storage)
		: EntityCache<ICostCenter, CostCenter, int>(cache, storage, CommonTypesMetaData.CostCenterKey), ICostCenterCache
{
}

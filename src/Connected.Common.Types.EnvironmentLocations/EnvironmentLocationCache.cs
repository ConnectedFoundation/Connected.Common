using Connected.Caching;
using Connected.Collections.Tagging;
using Connected.Storage;
using System.Collections.Immutable;

namespace Connected.Common.Types.EnvironmentLocations;

internal sealed class EnvironmentLocationCache(ICachingService cache, IStorageProvider storage)
		: EntityCache<IEnvironmentLocation, EnvironmentLocation, int>(cache, storage, CommonTypesMetaData.WorkplaceKey), IEnvironmentLocationCache
{
	private static TagIndexer<IEnvironmentLocation, int> TagsIndex { get; } = new();

	protected override async Task OnInitialized()
	{
		TagsIndex.Index(await All());

		await base.OnInitialized();
	}

	protected override async Task OnInvalidated(int id)
	{
		if (await Get(id) is IEnvironmentLocation unit)
			TagsIndex.Invalidate(unit);
		else
			TagsIndex.Remove(id);

		await base.OnInvalidated(id);
	}

	protected override Task OnRemoved(int id)
	{
		TagsIndex.Remove(id);

		return base.OnRemoved(id);
	}

	public async Task<IImmutableList<IEnvironmentLocation>> Query(List<string> tags)
	{
		if (!Initialized)
			await All();

		return TagsIndex.Query(tags);
	}
}

using Connected.Caching;
using Connected.Collections.Tagging;
using Connected.Storage;
using System.Collections.Immutable;

namespace Connected.Common.Types.OrganizationUnits;

internal sealed class OrganizationUnitCache(ICachingService cache, IStorageProvider storage)
		: EntityCache<OrganizationUnit, int>(cache, storage, CommonTypesMetaData.OrganizationUnitKey), IOrganizationUnitCache
{
	private static TagIndexer<OrganizationUnit, int> TagsIndex { get; } = new();

	protected override async Task OnInitialized()
	{
		TagsIndex.Index(await All());

		await base.OnInitialized();
	}

	protected override async Task OnInvalidated(int id)
	{
		if (await Get(id) is OrganizationUnit unit)
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

	public async Task<IImmutableList<OrganizationUnit>> Query(List<string> tags)
	{
		if (!Initialized)
			await All();

		return TagsIndex.Query(tags);
	}
}

using Connected.Entities;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Common.Types.MeasureUnits;
internal sealed class Lookup(IMeasureUnitCache cache)
	: ServiceFunction<IPrimaryKeyListDto<int>, ImmutableList<IMeasureUnit>>
{

	protected override async Task<ImmutableList<IMeasureUnit>> OnInvoke()
	{
		return await cache.AsEntities<IMeasureUnit>(f => Dto.Items.Any(g => g == f.Id));
	}
}

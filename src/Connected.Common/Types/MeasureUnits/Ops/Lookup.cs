using Connected.Entities;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Common.Types.MeasureUnits.Ops;
internal sealed class Lookup(IMeasureUnitCache cache)
	: ServiceFunction<IPrimaryKeyListDto<int>, IImmutableList<IMeasureUnit>>
{

	protected override async Task<IImmutableList<IMeasureUnit>> OnInvoke()
	{
		return await cache.AsEntities<IMeasureUnit>(f => Dto.Items.Any(g => g == f.Id));
	}
}

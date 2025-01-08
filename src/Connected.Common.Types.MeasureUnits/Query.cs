using Connected.Entities;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Common.Types.MeasureUnits;
internal sealed class Query(IMeasureUnitCache cache)
	: ServiceFunction<IQueryDto, ImmutableList<IMeasureUnit>>
{

	protected override async Task<ImmutableList<IMeasureUnit>> OnInvoke()
	{
		return await cache.WithDto(Dto).AsEntities<IMeasureUnit>();
	}
}

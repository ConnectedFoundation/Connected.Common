using Connected.Entities;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Common.Types.MeasureUnits.Ops;
internal sealed class Query(IMeasureUnitCache cache)
	: ServiceFunction<IQueryDto, IImmutableList<IMeasureUnit>>
{

	protected override async Task<IImmutableList<IMeasureUnit>> OnInvoke()
	{
		return await cache.WithDto(Dto).AsEntities();
	}
}

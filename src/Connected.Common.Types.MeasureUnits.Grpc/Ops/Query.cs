using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Common.Types.MeasureUnits.Ops;
internal sealed class Query
	: ServiceFunction<IQueryDto, ImmutableList<IMeasureUnit>>
{

	protected override Task<ImmutableList<IMeasureUnit>> OnInvoke()
	{
		throw new NotImplementedException();
	}
}

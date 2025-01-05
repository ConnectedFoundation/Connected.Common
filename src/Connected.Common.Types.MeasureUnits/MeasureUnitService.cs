using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Common.Types.MeasureUnits;
internal sealed class MeasureUnitService(IServiceProvider services) : Service(services), IMeasureUnitService
{
	public async Task Delete(IPrimaryKeyDto<int> dto)
	{
		await Invoke(GetOperation<Delete>(), dto);
	}

	public Task<int> Insert(IInsertMeasureUnitDto dto)
	{
		throw new NotImplementedException();
	}

	public Task<ImmutableList<IMeasureUnit>> Query(IQueryDto? dto)
	{
		throw new NotImplementedException();
	}

	public Task<ImmutableList<IMeasureUnit>> Query(IPrimaryKeyListDto<int> dto)
	{
		throw new NotImplementedException();
	}

	public Task<IMeasureUnit?> Select(IPrimaryKeyDto<int> dto)
	{
		throw new NotImplementedException();
	}

	public Task<IMeasureUnit?> Select(ISelectMeasureUnitDto dto)
	{
		throw new NotImplementedException();
	}

	public Task Update(IUpdateMeasureUnitDto dto)
	{
		throw new NotImplementedException();
	}
}

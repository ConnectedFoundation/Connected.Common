using Connected.Common.Types.MeasureUnits.Dtos;
using Connected.Common.Types.MeasureUnits.Ops;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Common.Types.MeasureUnits;
internal sealed class MeasureUnitService(IServiceProvider services) : Service(services), IMeasureUnitService
{
	public Task Delete(IPrimaryKeyDto<int> dto)
	{
		throw new NotImplementedException();
	}

	public Task<int> Insert(IInsertMeasureUnitDto dto)
	{
		throw new NotImplementedException();
	}

	public Task<IImmutableList<IMeasureUnit>> Query(IQueryDto? dto)
	{
		throw new NotImplementedException();
	}

	public Task<IImmutableList<IMeasureUnit>> Query(IPrimaryKeyListDto<int> dto)
	{
		throw new NotImplementedException();
	}

	public async Task<IMeasureUnit?> Select(IPrimaryKeyDto<int> dto)
	{
		return await Invoke(GetOperation<Select>(), dto);
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

using Connected.Annotations;
using Connected.Common.Types.MeasureUnits.Dtos;
using Connected.Common.Types.MeasureUnits.Ops;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Common.Types.MeasureUnits;

[ServiceVisibility(ServiceVisibilityScope.All)]
internal sealed class MeasureUnitService(IServiceProvider services) : Service(services), IMeasureUnitService
{
	public async Task Delete(IPrimaryKeyDto<int> dto)
	{
		await Invoke(GetOperation<Delete>(), dto);
	}

	public async Task<int> Insert(IInsertMeasureUnitDto dto)
	{
		return await Invoke(GetOperation<Insert>(), dto);
	}

	public async Task<IImmutableList<IMeasureUnit>> Query(IQueryDto? dto)
	{
		return await Invoke(GetOperation<Query>(), dto ?? QueryDto.NoPaging);
	}

	public async Task<IImmutableList<IMeasureUnit>> Query(IPrimaryKeyListDto<int> dto)
	{
		return await Invoke(GetOperation<Lookup>(), dto);
	}

	public async Task<IMeasureUnit?> Select(IPrimaryKeyDto<int> dto)
	{
		return await Invoke(GetOperation<Select>(), dto);
	}

	public async Task<IMeasureUnit?> Select(ISelectMeasureUnitDto dto)
	{
		return await Invoke(GetOperation<SelectByCode>(), dto);
	}

	public async Task Update(IUpdateMeasureUnitDto dto)
	{
		await Invoke(GetOperation<Update>(), dto);
	}
}

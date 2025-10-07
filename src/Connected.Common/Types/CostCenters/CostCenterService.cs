using Connected.Common.Types.CostCenters.Dtos;
using Connected.Common.Types.CostCenters.Ops;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Common.Types.CostCenters;
internal sealed class CostCenterService(IServiceProvider services)
		: Service(services), ICostCenterService
{
	public async Task Delete(IPrimaryKeyDto<int> dto)
	{
		await Invoke(GetOperation<Delete>(), dto);
	}

	public async Task<int> Insert(IInsertCostCenterDto dto)
	{
		return await Invoke(GetOperation<Insert>(), dto);
	}

	public async Task<IImmutableList<ICostCenter>> Query(IQueryDto? dto)
	{
		return await Invoke(GetOperation<Query>(), dto ?? QueryDto.NoPaging);
	}

	public async Task<IImmutableList<ICostCenter>> Query(IPrimaryKeyListDto<int> dto)
	{
		return await Invoke(GetOperation<Lookup>(), dto);
	}

	public async Task<ICostCenter?> Select(IPrimaryKeyDto<int> dto)
	{
		return await Invoke(GetOperation<Select>(), dto);
	}

	public async Task Update(IUpdateCostCenterDto dto)
	{
		await Invoke(GetOperation<Update>(), dto);
	}
}

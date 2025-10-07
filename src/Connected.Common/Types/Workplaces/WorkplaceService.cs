using Connected.Common.Types.Workplaces.Dtos;
using Connected.Common.Types.Workplaces.Ops;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Common.Types.Workplaces;

internal sealed class WorkplaceService(IServiceProvider services)
	: Service(services), IWorkplaceService
{
	public async Task Delete(IPrimaryKeyDto<int> dto)
	{
		await Invoke(GetOperation<Delete>(), dto);
	}

	public async Task<int> Insert(IInsertWorkplaceDto dto)
	{
		return await Invoke(GetOperation<Insert>(), dto);
	}

	public async Task Patch(IPatchDto<int> dto)
	{
		await Invoke(GetOperation<Patch>(), dto);
	}

	public async Task<IImmutableList<IWorkplace>> Query(IQueryDto? dto)
	{
		return await Invoke(GetOperation<Query>(), dto ?? QueryDto.NoPaging);
	}

	public Task<IImmutableList<IWorkplace>> Query(ITagListDto dto)
	{
		return Invoke(GetOperation<QueryByTags>(), dto);
	}

	public async Task<IWorkplace?> Select(IPrimaryKeyDto<int> dto)
	{
		return await Invoke(GetOperation<Select>(), dto);
	}

	public async Task Update(IUpdateWorkplaceDto dto)
	{
		await Invoke(GetOperation<Update>(), dto);
	}
}

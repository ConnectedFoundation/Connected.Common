using Connected.Common.Types.EnvironmentLocations.Dtos;
using Connected.Common.Types.EnvironmentLocations.Ops;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Common.Types.EnvironmentLocations;

internal sealed class EnvironmentLocationService(IServiceProvider services)
	: Service(services), IEnvironmentLocationService
{
	public async Task Delete(IPrimaryKeyDto<int> dto)
	{
		await Invoke(GetOperation<Delete>(), dto);
	}

	public async Task<int> Insert(IInsertEnvironmentLocationDto dto)
	{
		return await Invoke(GetOperation<Insert>(), dto);
	}

	public async Task Patch(IPatchDto<int> dto)
	{
		await Invoke(GetOperation<Patch>(), dto);
	}

	public async Task<IImmutableList<IEnvironmentLocation>> Query(IQueryDto? dto)
	{
		return await Invoke(GetOperation<Query>(), dto ?? QueryDto.NoPaging);
	}

	public Task<IImmutableList<IEnvironmentLocation>> Query(ITagListDto dto)
	{
		return Invoke(GetOperation<QueryByTags>(), dto);
	}

	public Task<IImmutableList<IEnvironmentLocation>> Query(IHeadDto<int> dto)
	{
		return Invoke(GetOperation<QueryByHead>(), dto);
	}

	public async Task<IEnvironmentLocation?> Select(IPrimaryKeyDto<int> dto)
	{
		return await Invoke(GetOperation<Select>(), dto);
	}

	public async Task Update(IUpdateEnvironmentLocationDto dto)
	{
		await Invoke(GetOperation<Update>(), dto);
	}
}

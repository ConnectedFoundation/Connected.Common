using Connected.Common.Types.OrganizationUnits.Dtos;
using Connected.Common.Types.OrganizationUnits.Ops;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Common.Types.OrganizationUnits;

internal sealed class OrganizationUnitService(IServiceProvider services)
	: Service(services), IOrganizationUnitService
{
	public async Task Delete(IPrimaryKeyDto<int> dto)
	{
		await Invoke(GetOperation<Delete>(), dto);
	}

	public async Task<int> Insert(IInsertOrganizationUnitDto dto)
	{
		return await Invoke(GetOperation<Insert>(), dto);
	}

	public async Task Patch(IPatchDto<int> dto)
	{
		await Invoke(GetOperation<Patch>(), dto);
	}

	public async Task<IImmutableList<IOrganizationUnit>> Query(IQueryDto? dto)
	{
		return await Invoke(GetOperation<Query>(), dto ?? QueryDto.NoPaging);
	}

	public async Task<IImmutableList<IOrganizationUnit>> Query(IParentDto<int?> dto)
	{
		return await Invoke(GetOperation<QueryByParent>(), dto);
	}

	public Task<IImmutableList<IOrganizationUnit>> Query(ITagListDto dto)
	{
		return Invoke(GetOperation<QueryByTags>(), dto);
	}

	public async Task<IOrganizationUnit?> Select(IPrimaryKeyDto<int> dto)
	{
		return await Invoke(GetOperation<Select>(), dto);
	}

	public async Task Update(IUpdateOrganizationUnitDto dto)
	{
		await Invoke(GetOperation<Update>(), dto);
	}
}

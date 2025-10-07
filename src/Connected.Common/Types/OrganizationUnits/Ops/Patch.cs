using Connected.Common.Types.OrganizationUnits.Dtos;
using Connected.Services;

namespace Connected.Common.Types.OrganizationUnits.Ops;

internal sealed class Patch(IOrganizationUnitService organizationUnits)
  : ServiceAction<IPatchDto<int>>
{
	protected override async Task OnInvoke()
	{
		var entity = await organizationUnits.Select(Dto) ?? throw new NullReferenceException(Strings.ErrEntityExpected);
		var dto = Dto.Patch<IUpdateOrganizationUnitDto, IOrganizationUnit>(entity);

		await organizationUnits.Update(dto);
	}
}

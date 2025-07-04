using Connected.Common.Types.Workplaces.Dtos;
using Connected.Services;

namespace Connected.Common.Types.Workplaces.Ops;

internal sealed class Patch(IWorkplaceService workplaces)
  : ServiceAction<IPatchDto<int>>
{
	protected override async Task OnInvoke()
	{
		var entity = await workplaces.Select(Dto) ?? throw new NullReferenceException(Strings.ErrEntityExpected);
		var dto = Dto.Patch<IUpdateWorkplaceDto, IWorkplace>(entity);

		await workplaces.Update(dto);
	}
}

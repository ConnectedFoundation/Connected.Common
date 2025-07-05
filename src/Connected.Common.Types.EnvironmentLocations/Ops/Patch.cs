using Connected.Common.Types.EnvironmentLocations.Dtos;
using Connected.Services;

namespace Connected.Common.Types.EnvironmentLocations.Ops;

internal sealed class Patch(IEnvironmentLocationService locations)
  : ServiceAction<IPatchDto<int>>
{
	protected override async Task OnInvoke()
	{
		var entity = await locations.Select(Dto) ?? throw new NullReferenceException(Strings.ErrEntityExpected);
		var dto = Dto.Patch<IUpdateEnvironmentLocationDto, IEnvironmentLocation>(entity);

		await locations.Update(dto);
	}
}

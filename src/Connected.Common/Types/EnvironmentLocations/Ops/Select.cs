using Connected.Services;

namespace Connected.Common.Types.EnvironmentLocations.Ops;

internal sealed class Select(IEnvironmentLocationCache cache)
  : ServiceFunction<IPrimaryKeyDto<int>, IEnvironmentLocation?>
{
	protected override async Task<IEnvironmentLocation?> OnInvoke()
	{
		return await cache.Get(Dto.Id);
	}
}

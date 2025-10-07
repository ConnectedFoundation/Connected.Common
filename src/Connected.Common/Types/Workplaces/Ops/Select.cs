using Connected.Services;

namespace Connected.Common.Types.Workplaces.Ops;

internal sealed class Select(IWorkplaceCache cache)
  : ServiceFunction<IPrimaryKeyDto<int>, IWorkplace?>
{
	protected override async Task<IWorkplace?> OnInvoke()
	{
		return await cache.Get(Dto.Id);
	}
}

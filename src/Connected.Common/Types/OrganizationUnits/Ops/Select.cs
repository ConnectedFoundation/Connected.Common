using Connected.Services;

namespace Connected.Common.Types.OrganizationUnits.Ops;

internal sealed class Select(IOrganizationUnitCache cache)
  : ServiceFunction<IPrimaryKeyDto<int>, IOrganizationUnit?>
{
	protected override async Task<IOrganizationUnit?> OnInvoke()
	{
		return await cache.Get(Dto.Id);
	}
}

using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Common.Types.OrganizationUnits.Ops;

internal sealed class Delete(IOrganizationUnitService organizationUnits, IEventService events, IOrganizationUnitCache cache, IStorageProvider storage)
  : ServiceAction<IPrimaryKeyDto<int>>
{
	protected override async Task OnInvoke()
	{
		var entity = SetState(await organizationUnits.Select(Dto)) as OrganizationUnit ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<OrganizationUnit>().Update(entity.Merge(Dto, State.Delete));
		await cache.Remove(entity.Id);
		await events.Deleted(this, organizationUnits, Dto.Id);
	}
}

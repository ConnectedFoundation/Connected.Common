using Connected.Common.Types.OrganizationUnits.Dtos;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Common.Types.OrganizationUnits.Ops;

internal sealed class Update(IOrganizationUnitService organizationUnits, IEventService events, IOrganizationUnitCache cache, IStorageProvider storage)
  : ServiceAction<IUpdateOrganizationUnitDto>
{
	protected override async Task OnInvoke()
	{
		var entity = SetState(await organizationUnits.Select(Dto)) as OrganizationUnit ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<OrganizationUnit>().Update(entity.Merge(Dto, Entities.State.Update), Dto, async () =>
		{
			await cache.Refresh(entity.Id);

			return SetState(await organizationUnits.Select(Dto)) as OrganizationUnit ?? throw new NullReferenceException(Strings.ErrEntityExpected);
		}, Caller);

		await cache.Refresh(entity.Id);
		await events.Updated(this, organizationUnits, entity.Id);
	}
}

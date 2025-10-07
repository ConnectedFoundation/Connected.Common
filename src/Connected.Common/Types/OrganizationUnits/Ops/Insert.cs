using Connected.Common.Types.OrganizationUnits.Dtos;
using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Common.Types.OrganizationUnits.Ops;

internal sealed class Insert(IOrganizationUnitService organizationUnits, IEventService events, IOrganizationUnitCache cache, IStorageProvider storage)
  : ServiceFunction<IInsertOrganizationUnitDto, int>
{
	protected override async Task<int> OnInvoke()
	{
		var entity = SetState(await storage.Open<OrganizationUnit>().Update(Dto.AsEntity<OrganizationUnit>(State.Add))) ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await cache.Refresh(entity.Id);
		await events.Deleted(this, organizationUnits, entity.Id);

		return entity.Id;
	}
}

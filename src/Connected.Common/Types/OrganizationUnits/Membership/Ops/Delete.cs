using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Common.Types.OrganizationUnits.Membership.Ops;
internal sealed class Delete(IStorageProvider storage, IEventService events, IOrganizationUnitMembershipService membership, IOrganizationUnitMembershipCache cache)
	: ServiceAction<IPrimaryKeyDto<int>>
{
	protected override async Task OnInvoke()
	{
		var entity = SetState(await cache.AsEntity(f => f.Id == Dto.Id)).Required();

		await storage.Open<OrganizationUnitMembership>().Update(Dto.AsEntity<OrganizationUnitMembership>(State.Delete));
		await cache.Remove(entity.Id);
		await events.Deleted(this, membership, entity.Id);
	}
}

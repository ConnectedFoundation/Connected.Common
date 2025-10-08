using Connected.Common.Types.OrganizationUnits.Membership.Dtos;
using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Common.Types.OrganizationUnits.Membership.Ops;
internal sealed class Insert(IStorageProvider storage, IEventService events, IOrganizationUnitMembershipService membership, IOrganizationUnitMembershipCache cache)
	: ServiceFunction<IInsertOrganizationUnitMembershipDto, int>
{
	protected override async Task<int> OnInvoke()
	{
		var entity = SetState(await storage.Open<OrganizationUnitMembership>().Update(Dto.AsEntity<OrganizationUnitMembership>(Entities.State.Add))).Required();

		await cache.Refresh(entity.Id);
		await events.Inserted(this, membership, entity.Id);

		return entity.Id;
	}
}

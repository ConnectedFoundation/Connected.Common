using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Common.Types.EnvironmentLocations.Ops;

internal sealed class Delete(IEnvironmentLocationService locations, IEventService events, IEnvironmentLocationCache cache, IStorageProvider storage)
  : ServiceAction<IPrimaryKeyDto<int>>
{
	protected override async Task OnInvoke()
	{
		var entity = SetState(await locations.Select(Dto)) as EnvironmentLocation ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<EnvironmentLocation>().Update(entity.Merge(Dto, State.Delete));
		await cache.Remove(entity.Id);
		await events.Deleted(this, locations, Dto.Id);
	}
}

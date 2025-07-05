using Connected.Common.Types.EnvironmentLocations.Dtos;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Common.Types.EnvironmentLocations.Ops;

internal sealed class Update(IEnvironmentLocationService locations, IEventService events, IEnvironmentLocationCache cache, IStorageProvider storage)
  : ServiceAction<IUpdateEnvironmentLocationDto>
{
	protected override async Task OnInvoke()
	{
		var entity = SetState(await locations.Select(Dto)) as EnvironmentLocation ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<EnvironmentLocation>().Update(entity.Merge(Dto, Entities.State.Update), Dto, async () =>
		{
			await cache.Refresh(entity.Id);

			return SetState(await locations.Select(Dto)) as EnvironmentLocation ?? throw new NullReferenceException(Strings.ErrEntityExpected);
		}, Caller);

		await cache.Refresh(entity.Id);
		await events.Updated(this, locations, entity.Id);
	}
}

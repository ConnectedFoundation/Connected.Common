using Connected.Common.Types.EnvironmentLocations.Dtos;
using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Common.Types.EnvironmentLocations.Ops;

internal sealed class Insert(IEnvironmentLocationService locations, IEventService events, IEnvironmentLocationCache cache, IStorageProvider storage)
  : ServiceFunction<IInsertEnvironmentLocationDto, int>
{
	protected override async Task<int> OnInvoke()
	{
		var entity = SetState(await storage.Open<EnvironmentLocation>().Update(Dto.AsEntity<EnvironmentLocation>(State.Add))) ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await cache.Refresh(entity.Id);
		await events.Deleted(this, locations, entity.Id);

		return entity.Id;
	}
}

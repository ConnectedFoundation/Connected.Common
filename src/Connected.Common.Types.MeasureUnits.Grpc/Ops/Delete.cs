using Connected.Notifications;
using Connected.Services;
using Grpc.Net.Client;

namespace Connected.Common.Types.MeasureUnits.Ops;
internal sealed class Delete(IEventService events, IMeasureUnitService measureUnits)
	: ServiceAction<IPrimaryKeyDto<int>>
{

	protected override async Task OnInvoke()
	{
		SetState(await measureUnits.Select(Dto));

		using var channel = GrpcChannel.ForAddress("http://localhost:5000");
		var client = new Grpc.MeasureUnitService.MeasureUnitServiceClient(channel);
		var result = await client.DeleteAsync(new Grpc.IdDto { Id = Dto.Id });

		await events.Deleted(this, measureUnits, Dto);
	}
}

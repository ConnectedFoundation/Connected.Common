using Connected.Authentication;
using Connected.Net.Grpc;
using Connected.Reflection;
using Connected.Services;
using Grpc.Core;

namespace Connected.Common.Types.MeasureUnits.Ops;
internal sealed class Select(IAuthenticationService authentication, IGrpcService grpc)
	: ServiceFunction<IPrimaryKeyDto<int>, IMeasureUnit?>
{

	protected override async Task<IMeasureUnit?> OnInvoke()
	{
		using var channel = await grpc.ResolveChannel<IMeasureUnitService>();
		var client = new Grpc.MeasureUnitService.MeasureUnitServiceClient(channel);
		var result = await client.SelectAsync(new Grpc.IdDto { Id = Dto.Id }, await new Metadata().WithCurrentCredentials(authentication));

		if (result is null)
			return null;

		return Serializer.Merge<MeasureUnit>(result);
	}
}

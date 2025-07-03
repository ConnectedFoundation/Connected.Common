using Connected.Annotations;
using Connected.Common.Types.MeasureUnits.Dtos;
using Connected.Common.Types.MeasureUnits.Grpc;
using Connected.Net.Grpc;
using Connected.Services;
using Grpc.Core;

namespace Connected.Common.Types.MeasureUnits.GRpc;

[ServiceProxy<IMeasureUnitService>]
internal sealed class MeasureUnitProxy : Grpc.MeasureUnitService.MeasureUnitServiceBase
{
	public override async Task<Grpc.MeasureUnit?> Select(IdDto request, ServerCallContext context) => await context.Invoke<IMeasureUnitService, IPrimaryKeyDto<int>, Grpc.MeasureUnit>(nameof(IMeasureUnitService.Select), request);
	public override async Task<Grpc.MeasureUnits> Query(Grpc.QueryDto request, ServerCallContext context) => await context.Invoke<IMeasureUnitService, IQueryDto, Grpc.MeasureUnits>(nameof(IMeasureUnitService.Query), request);
	public override async Task<Id> Insert(InsertDto request, ServerCallContext context) => await context.Invoke<IMeasureUnitService, IInsertMeasureUnitDto, Id>(nameof(IMeasureUnitService.Insert), request);
	public override async Task<Grpc.Void> Update(UpdateDto request, ServerCallContext context) => await context.Invoke<IMeasureUnitService, IInsertMeasureUnitDto, Grpc.Void>(nameof(IMeasureUnitService.Update), request);
	public override async Task<Grpc.Void> Delete(IdDto request, ServerCallContext context) => await context.Invoke<IMeasureUnitService, IInsertMeasureUnitDto, Grpc.Void>(nameof(IMeasureUnitService.Delete), request);
}
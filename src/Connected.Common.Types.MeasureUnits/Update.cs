using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Common.Types.MeasureUnits;
internal sealed class Update(IStorageProvider storage, IEventService events, IMeasureUnitCache cache, IMeasureUnitService measureUnits)
	: ServiceAction<IUpdateMeasureUnitDto>
{

	protected override async Task OnInvoke()
	{
		var existing = SetState(await measureUnits.Select(Dto.AsDto<IPrimaryKeyDto<int>>()) as MeasureUnit) ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<MeasureUnit>().Update(Dto.AsEntity<MeasureUnit>(State.Default), Dto, async () =>
		{
			await cache.Refresh(Dto.Id);

			return SetState(await measureUnits.Select(Dto.AsDto<IPrimaryKeyDto<int>>()) as MeasureUnit);
		}, Caller);

		await cache.Refresh(Dto.Id);
		await events.Updated(this, measureUnits, Dto.Id);
	}
}

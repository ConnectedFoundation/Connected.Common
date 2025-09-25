using Connected.Annotations;
using Connected.Common.Types.Numbering.Incremental;
using Connected.Common.Types.Numbering.Incremental.Dtos;
using Connected.Services;

namespace Connected.Common.Types.Numbering;

[Middleware<IIncrementalNumberService>(nameof(IIncrementalNumberService.Next))]
internal sealed class NextCalibrator(IIncrementalNumberService numbers, IIncrementalNumberNextAmbient ambient)
	: Calibrator<IIncrementalNumberDto>
{
	protected override async Task OnInvoke()
	{
		var existing = await numbers.Select(Dto);

		if (existing is null)
		{
			ambient.Value = 1;

			return;
		}

		if (existing.TimeStamp.GetValueOrDefault().Year != DateTimeOffset.UtcNow.Year)
			ambient.Value = 1;
		else
			ambient.Value = existing.Value.GetValueOrDefault() + 1;
	}
}

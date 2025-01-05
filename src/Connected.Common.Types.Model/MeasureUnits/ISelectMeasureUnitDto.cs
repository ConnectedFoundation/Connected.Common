using Connected.Services;

namespace Connected.Common.Types.MeasureUnits;

public interface ISelectMeasureUnitDto : IDto
{
	string Code { get; set; }
}
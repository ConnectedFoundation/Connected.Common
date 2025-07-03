using Connected.Services;

namespace Connected.Common.Types.MeasureUnits.Dtos;

public interface ISelectMeasureUnitDto : IDto
{
	string Code { get; set; }
}
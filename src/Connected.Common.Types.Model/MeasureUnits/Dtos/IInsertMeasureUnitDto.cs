using Connected.Entities;
using Connected.Services;

namespace Connected.Common.Types.MeasureUnits.Dtos;

public interface IInsertMeasureUnitDto : IDto
{
	string Name { get; set; }
	string Code { get; set; }
	byte Precision { get; set; }
	Status Status { get; set; }
}

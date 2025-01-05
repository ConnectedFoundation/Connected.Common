using Connected.Entities;
using Connected.Services;

namespace Connected.Common.Types.MeasureUnits;

public interface IUpdateMeasureUnitDto : IDto
{
	int Id { get; set; }
	string Name { get; set; }
	string Code { get; set; }
	byte Precision { get; set; }
	Status Status { get; set; }
}

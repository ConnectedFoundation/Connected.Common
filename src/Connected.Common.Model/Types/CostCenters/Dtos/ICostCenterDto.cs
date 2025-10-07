using Connected.Entities;
using Connected.Services;

namespace Connected.Common.Types.CostCenters.Dtos;
public interface ICostCenterDto : IDto
{
	string Name { get; set; }
	string Code { get; set; }
	Status Status { get; set; }
}

using Connected.Common.Types.CostCenters.Dtos;
using Connected.Core.Services.Mock;
using Connected.Entities;

namespace Connected.Common.Mock.Dtos;
public class CostCenterDtoMock
	: DtoMock, ICostCenterDto
{
	public required string Name { get; set; }
	public required string Code { get; set; }
	public Status Status { get; set; }
}

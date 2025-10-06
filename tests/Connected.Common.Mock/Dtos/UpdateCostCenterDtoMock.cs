using Connected.Common.Types.CostCenters.Dtos;

namespace Connected.Common.Mock.Dtos;
public class UpdateCostCenterDtoMock
	: CostCenterDtoMock, IUpdateCostCenterDto
{
	public int Id { get; set; }
}

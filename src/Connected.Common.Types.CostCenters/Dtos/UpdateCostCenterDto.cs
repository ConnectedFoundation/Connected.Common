namespace Connected.Common.Types.CostCenters.Dtos;
internal sealed class UpdateCostCenterDto : CostCenterDto, IUpdateCostCenterDto
{
	public int Id { get; set; }
}

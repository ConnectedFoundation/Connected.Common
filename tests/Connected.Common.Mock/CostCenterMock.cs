using Connected.Common.Types.CostCenters;
using Connected.Core.Entities.Mock;
using Connected.Entities;

namespace Connected.Common.Mock;
public class CostCenterMock
	: EntityMock<int>, ICostCenter
{
	public required string Name { get; init; }
	public required string Code { get; init; }
	public Status Status { get; init; }
}

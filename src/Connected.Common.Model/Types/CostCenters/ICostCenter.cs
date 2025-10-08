using Connected.Annotations.Entities;
using Connected.Entities;

namespace Connected.Common.Types.CostCenters;

[EntityKey(CommonMetaData.CostCenterKey)]
public interface ICostCenter : IEntity<int>
{
	string Name { get; init; }
	string Code { get; init; }
	Status Status { get; init; }
}

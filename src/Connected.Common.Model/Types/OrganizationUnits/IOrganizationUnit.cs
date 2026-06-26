using Connected.Annotations.Entities;
using Connected.Entities;

namespace Connected.Common.Types.OrganizationUnits;

[EntityKey(CommonMetaData.OrganizationUnitKey)]
public interface IOrganizationUnit : ITaggedEntity<int>
{
	string Name { get; init; }
	string Code { get; init; }
	int? Parent { get; init; }
	Status Status { get; init; }
}

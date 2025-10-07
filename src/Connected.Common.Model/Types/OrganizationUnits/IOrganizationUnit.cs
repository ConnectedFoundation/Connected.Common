using Connected.Entities;

namespace Connected.Common.Types.OrganizationUnits;

public interface IOrganizationUnit : ITaggedEntity<int>
{
	string Name { get; init; }
	string Code { get; init; }
	int? Parent { get; init; }
	Status Status { get; init; }
}

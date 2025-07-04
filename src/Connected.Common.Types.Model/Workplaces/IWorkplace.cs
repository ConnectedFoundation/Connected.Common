using Connected.Entities;

namespace Connected.Common.Types.Workplaces;

public interface IWorkplace : ITaggedEntity<int>
{
	string Name { get; init; }
	string Code { get; init; }
	int? OrganizationUnit { get; init; }
	int? OrganizationLocation { get; init; }
	Status Status { get; init; }
}

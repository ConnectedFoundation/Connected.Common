using Connected.Entities;
using Connected.Services;

namespace Connected.Common.Types.Workplaces.Dtos;

public interface IWorkplaceDto : IDto
{
	string Name { get; set; }
	string Code { get; set; }
	int? OrganizationUnit { get; set; }
	int? OrganizationLocation { get; set; }
	Status Status { get; set; }
	string? Tags { get; set; }
}

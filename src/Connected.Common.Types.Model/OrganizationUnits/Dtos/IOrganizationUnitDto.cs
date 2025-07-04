using Connected.Entities;
using Connected.Services;

namespace Connected.Common.Types.OrganizationUnits.Dtos;

public interface IOrganizationUnitDto : IDto
{
	string Name { get; set; }
	string Code { get; set; }
	int? Parent { get; set; }
	string? Tags { get; set; }
	Status Status { get; set; }
}

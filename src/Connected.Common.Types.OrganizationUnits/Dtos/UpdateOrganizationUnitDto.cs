using Connected.Annotations;

namespace Connected.Common.Types.OrganizationUnits.Dtos;

internal sealed class UpdateOrganizationUnitDto : OrganizationUnitDto, IUpdateOrganizationUnitDto
{
	[MinValue(1)]
	public int Id { get; set; }
}

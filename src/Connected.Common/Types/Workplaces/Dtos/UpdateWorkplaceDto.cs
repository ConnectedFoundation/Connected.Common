using Connected.Annotations;

namespace Connected.Common.Types.Workplaces.Dtos;

internal sealed class UpdateWorkplaceDto : WorkplaceDto, IUpdateWorkplaceDto
{
	[MinValue(1)]
	public int Id { get; set; }
}

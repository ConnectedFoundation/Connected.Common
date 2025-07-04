using Connected.Annotations.Entities;
using Connected.Common.Types.MeasureUnits;
using Connected.Common.Types.OrganizationUnits;
using Connected.Common.Types.Workplaces;

namespace Connected.Common.Types;
public static class CommonTypesMetaData
{
	public const string MeasureUnitKey = $"{SchemaAttribute.CommonSchema}.{nameof(IMeasureUnit)}";
	public const string OrganizationUnitKey = $"{SchemaAttribute.CommonSchema}.{nameof(IOrganizationUnit)}";
	public const string WorkplaceKey = $"{SchemaAttribute.CommonSchema}.{nameof(IWorkplace)}";
}

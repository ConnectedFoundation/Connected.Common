using Connected.Annotations.Entities;
using Connected.Common.Types.MeasureUnits;
using Connected.Common.Types.OrganizationUnits;

namespace Connected.Common.Types;
public static class CommonTypesMetaData
{
	public const string MeasureUnitKey = $"{SchemaAttribute.CommonSchema}.{nameof(IMeasureUnit)}";
	public const string OrganizationUnitKey = $"{SchemaAttribute.CommonSchema}.{nameof(IOrganizationUnit)}";

	public const string LookupOperation = "lookup";
	public const string SelectByCodeOperation = "select-by-code";
	public const string QueryByParentOperation = "query-by-parent";
	public const string QueryByTagsOperation = "query-by-tags";
}

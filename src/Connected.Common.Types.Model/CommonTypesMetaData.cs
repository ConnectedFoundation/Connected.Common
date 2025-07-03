using Connected.Annotations.Entities;
using Connected.Common.Types.MeasureUnits;

namespace Connected.Common.Types;
public static class CommonTypesMetaData
{
	public const string MeasureUnitKey = $"{SchemaAttribute.CommonSchema}.{nameof(IMeasureUnit)}";

	public const string LookupOperation = "lookup";
	public const string SelectByCodeOperation = "select-by-code";
}

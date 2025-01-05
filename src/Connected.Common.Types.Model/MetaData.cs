using Connected.Annotations.Entities;
using Connected.Common.Types.MeasureUnits;

namespace Connected.Common.Types;
public static class MetaData
{
	public const string MeasureUnitKey = $"{SchemaAttribute.CommonSchema}.{nameof(IMeasureUnit)}";
}

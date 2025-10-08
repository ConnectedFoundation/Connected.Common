using Connected.Annotations.Entities;
using Connected.Common.Types.CostCenters;
using Connected.Common.Types.MeasureUnits;
using Connected.Common.Types.Numbering.Incremental;
using Connected.Common.Types.OrganizationUnits;
using Connected.Common.Types.OrganizationUnits.Membership;
using Connected.Common.Types.Workplaces;

namespace Connected.Common.Types;
public static class CommonMetaData
{
	public const string MeasureUnitKey = $"{SchemaAttribute.CommonSchema}.{nameof(IMeasureUnit)}";
	public const string OrganizationUnitKey = $"{SchemaAttribute.CommonSchema}.{nameof(IOrganizationUnit)}";
	public const string WorkplaceKey = $"{SchemaAttribute.CommonSchema}.{nameof(IWorkplace)}";
	public const string CostCenterKey = $"{SchemaAttribute.CommonSchema}.{nameof(ICostCenter)}";
	public const string IncrementalNumberKey = $"{SchemaAttribute.CommonSchema}.{nameof(IIncrementalNumber)}";
	public const string OrganizationUnitMembershipKey = $"{SchemaAttribute.CommonSchema}.{nameof(IOrganizationUnitMembership)}";
}

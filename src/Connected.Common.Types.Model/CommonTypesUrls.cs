namespace Connected.Common.Types;
public static class CommonTypesUrls
{
	private const string Namespace = "services/common-types";

	public const string MeasureUnits = $"{Namespace}/measure-units";
	public const string IncrementalNumbering = $"{Namespace}/numbering/incremental";
	public const string OrganizationUnits = $"{Namespace}/organization-units";
	public const string Workplaces = $"{Namespace}/organization-units/workplaces";
	public const string OrganizationUnitLocations = $"{Namespace}/organization-units/locations";

	public const string LookupOperation = "lookup";
	public const string SelectByCodeOperation = "select-by-code";
	public const string QueryByParentOperation = "query-by-parent";
	public const string QueryByTagsOperation = "query-by-tags";
}

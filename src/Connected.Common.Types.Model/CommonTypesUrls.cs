namespace Connected.Common.Types;
public static class CommonTypesUrls
{
	private const string Namespace = "services/common-types";

	public const string MeasureUnits = $"{Namespace}/measure-units";
	public const string IncrementalNumbering = $"{Namespace}/numbering/incremental";
	public const string OrganizationUnits = $"{Namespace}/organization-units";
	public const string Workplaces = $"{Namespace}/workplaces";
	public const string EnvironmentLocations = $"{Namespace}/environment-locations";
	public const string CostCenters = $"{Namespace}/cost-centers";

	public const string LookupOperation = "lookup";
	public const string SelectByCodeOperation = "select-by-code";
	public const string QueryByParentOperation = "query-by-parent";
	public const string QueryByTagsOperation = "query-by-tags";
	public const string QueryByHeadOperation = "query-by-head";
}

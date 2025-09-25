using Connected.Runtime;

namespace Connected.Common.Runtime;
internal sealed class CommonImage : RuntimeImage
{
	protected override void OnRegister()
	{
		Application.RegisterMicroService("Connected.Common.Types.CostCenters.dll");
		Application.RegisterMicroService("Connected.Common.Types.EnvironmentLocations.dll");
		Application.RegisterMicroService("Connected.Common.Types.MeasureUnits.dll");
		Application.RegisterMicroService("Connected.Common.Types.OrganizationUnits.dll");
		Application.RegisterMicroService("Connected.Common.Types.Workplaces.dll");
		Application.RegisterMicroService("Connected.Common.Types.Numbering.dll");
	}
}

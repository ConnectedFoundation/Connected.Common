using Connected.Runtime;

namespace Connected.Common;
internal sealed class CommonImage : RuntimeImage
{
	protected override void OnRegister()
	{
		RegisterDependency("Connected.Common.Extensions.dll");
	}
}

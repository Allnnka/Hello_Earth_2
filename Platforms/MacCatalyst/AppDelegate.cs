using Foundation;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace Hello_Earth_2
{
	[Register("AppDelegate")]
	public class AppDelegate : MauiUIApplicationDelegate
	{
		protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
	}
}
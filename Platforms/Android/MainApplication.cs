using Android.App;
using Android.Runtime;

namespace Masters_Summer_Project_CsharpPart2_Quiz;

[Application]
public class MainApplication : MauiApplication
{
	public MainApplication(IntPtr handle, JniHandleOwnership ownership)
		: base(handle, ownership)
	{


	}

	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}

namespace Masters_Summer_Project_CsharpPart2_Quiz;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(Views.LoginPage), typeof(Views.LoginPage));
		Routing.RegisterRoute(nameof(Views.RegisterPage), typeof(Views.RegisterPage));
		Routing.RegisterRoute(nameof(Views.HomePage), typeof(Views.HomePage));
		Routing.RegisterRoute(nameof(Views.ProfilePage), typeof(Views.ProfilePage));
	}
}

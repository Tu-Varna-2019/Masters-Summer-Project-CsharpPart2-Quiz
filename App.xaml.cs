using Masters_Summer_Project_CsharpPart2_Quiz.Views;
namespace Masters_Summer_Project_CsharpPart2_Quiz;

public partial class App : Application
{
	public IServiceProvider ServiceProvider { get; }
	public App(IServiceProvider serviceProvider)
	{
		InitializeComponent();
		ServiceProvider = serviceProvider;
		MainPage = new NavigationPage(new LoginPage());

	}

	protected override async void OnStart()
	{
		base.OnStart();
		if (MauiProgram.StartupException != null)
		{
			await MainPage.DisplayAlert("Startup Error", MauiProgram.StartupException.Message, "OK");
		}
	}

}

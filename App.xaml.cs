using Masters_Summer_Project_CsharpPart2_Quiz.Views;
using Masters_Summer_Project_CsharpPart2_Quiz.ViewModels;
namespace Masters_Summer_Project_CsharpPart2_Quiz;

public partial class App : Application
{
	public IServiceProvider ServiceProvider { get; }
	public App(IServiceProvider serviceProvider)
	{
		InitializeComponent();
		ServiceProvider = serviceProvider;
		//MainPage = new NavigationPage(new LoginPage(ServiceProvider.GetService<LoginViewModel>()));
		MainPage = new NavigationPage(new HomePage(ServiceProvider.GetService<HomeViewModel>()));
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

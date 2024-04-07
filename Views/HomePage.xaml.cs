using Masters_Summer_Project_CsharpPart2_Quiz.Helpers;
using Masters_Summer_Project_CsharpPart2_Quiz.ViewModels;

namespace Masters_Summer_Project_CsharpPart2_Quiz.Views;

public partial class HomePage : ContentPage
{
	public HomePage(HomeViewModel homeViewModel)
	{
		InitializeComponent();
		BindingContext = homeViewModel;

		AlertMessenger.RegisterForAlerts(this);
	}

	protected override void OnDisappearing()
	{
		base.OnDisappearing();
		AlertMessenger.UnregisterAlerts(this);
	}

	// private async void OnLogoutClicked(object sender, EventArgs e)
	// {
	// 	var loginViewModel = ((App)Application.Current).ServiceProvider.GetService<LoginViewModel>();
	// 	var loginPage = new LoginPage(loginViewModel);
	// 	await Navigation.PushAsync(loginPage);
	// }
}

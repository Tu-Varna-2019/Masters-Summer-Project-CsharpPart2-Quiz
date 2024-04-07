namespace Masters_Summer_Project_CsharpPart2_Quiz.Views;

using Masters_Summer_Project_CsharpPart2_Quiz.Helpers;
using Masters_Summer_Project_CsharpPart2_Quiz.ViewModels;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(RegisterViewModel registerViewModel)
	{
		InitializeComponent();
		BindingContext = registerViewModel;

		AlertMessenger.RegisterForAlerts(this);
	}

	protected override void OnDisappearing()
	{
		base.OnDisappearing();
		AlertMessenger.UnregisterAlerts(this);
	}

	private async void OnGoToLoginClicked(object sender, EventArgs e)
	{
		var loginViewModel = ((App)Application.Current).ServiceProvider.GetService<LoginViewModel>();
		var loginPage = new LoginPage(loginViewModel);
		await Navigation.PushAsync(loginPage);
	}

}

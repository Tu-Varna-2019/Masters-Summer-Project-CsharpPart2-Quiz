using Masters_Summer_Project_CsharpPart2_Quiz.Helpers;
using Masters_Summer_Project_CsharpPart2_Quiz.ViewModels;

namespace Masters_Summer_Project_CsharpPart2_Quiz.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel loginViewModel)
    {
        InitializeComponent();
        BindingContext = loginViewModel;

        AlertMessenger.RegisterForAlerts(this);
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        AlertMessenger.UnregisterAlerts(this);
    }

    private async void OnGoToRegisterClicked(object sender, EventArgs e)
    {
        var registerViewModel = ((App)Application.Current).ServiceProvider.GetService<RegisterViewModel>();
        var registerPage = new RegisterPage(registerViewModel);
        await Navigation.PushAsync(registerPage);
    }
}

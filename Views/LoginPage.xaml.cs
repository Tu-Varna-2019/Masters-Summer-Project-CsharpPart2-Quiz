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
}

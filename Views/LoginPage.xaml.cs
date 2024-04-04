using Masters_Summer_Project_CsharpPart2_Quiz.ViewModels;
namespace Masters_Summer_Project_CsharpPart2_Quiz.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnGoToRegisterClicked(object sender, EventArgs e)
    {
        try
        {
            var registerViewModel = ((App)Application.Current).ServiceProvider.GetService<RegisterViewModel>();

            var registerPage = new RegisterPage(registerViewModel);
            // Use the Navigation property directly, as the LoginPage is wrapped in a NavigationPage
            await Navigation.PushAsync(registerPage);

        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }

    }


}

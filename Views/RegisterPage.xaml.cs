namespace Masters_Summer_Project_CsharpPart2_Quiz.Views;
using Masters_Summer_Project_CsharpPart2_Quiz.ViewModels;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
		BindingContext = new RegisterViewModel();

		MessagingCenter.Subscribe<RegisterViewModel, string>(this, "RegisterSuccess", async (sender, arg) =>
		{
			await DisplayAlert("Success", arg, "OK");
		});

		MessagingCenter.Subscribe<RegisterViewModel, string>(this, "RegisterError", async (sender, arg) =>
		{
			await DisplayAlert("Error", arg, "OK");
		});
	}

	// Unsubscribe from messages when the page is disappearing to avoid memory leaks
	protected override void OnDisappearing()
	{
		base.OnDisappearing();
		MessagingCenter.Unsubscribe<RegisterViewModel, string>(this, "RegisterSuccess");
		MessagingCenter.Unsubscribe<RegisterViewModel, string>(this, "RegisterError");
	}
}

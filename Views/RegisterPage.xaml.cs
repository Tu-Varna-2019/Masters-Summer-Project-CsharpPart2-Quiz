namespace Masters_Summer_Project_CsharpPart2_Quiz.Views;

using CommunityToolkit.Mvvm.Messaging;
using Masters_Summer_Project_CsharpPart2_Quiz.ViewModels;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(RegisterViewModel registerViewModel)
	{
		InitializeComponent();
		BindingContext = registerViewModel;

		WeakReferenceMessenger.Default.Register<string, string>(this, "RegisterSuccess", (recipient, message) =>
		{
			HandleRegistrationMessage(message, true);
		});

		WeakReferenceMessenger.Default.Register<string, string>(this, "RegisterError", (recipient, message) =>
		{
			HandleRegistrationMessage(message, false);
		});



	}


	private void HandleRegistrationMessage(string message, bool isSuccess)
	{
		MainThread.BeginInvokeOnMainThread(async () =>
		{
			var title = isSuccess ? "Success" : "Error";
			await DisplayAlert(title, message, "OK");
			if (isSuccess)
			{
				await Navigation.PopAsync();
			}
		});
	}


	protected override void OnDisappearing()
	{
		base.OnDisappearing();
		// Cleanup to avoid memory leaks
		WeakReferenceMessenger.Default.UnregisterAll(this);
	}

}

namespace Masters_Summer_Project_CsharpPart2_Quiz.Views;

using CommunityToolkit.Mvvm.Messaging;
using Masters_Summer_Project_CsharpPart2_Quiz.ViewModels;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(RegisterViewModel registerViewModel)
	{
		InitializeComponent();
		BindingContext = registerViewModel;

		WeakReferenceMessenger.Default.Register<RegisterPage, string>(this, "RegisterSuccess", (recipient, message) =>
		{
			MainThread.BeginInvokeOnMainThread(async () =>
			{
				await DisplayAlert("Success", message.ToString(), "OK");
				await Navigation.PopAsync();
			});
		});

		WeakReferenceMessenger.Default.Register<RegisterPage, string>(this, "RegisterError", (recipient, message) =>
{
	MainThread.BeginInvokeOnMainThread(async () =>
	{
		await DisplayAlert("Error", message.ToString(), "OK");
		await Navigation.PopAsync();
	});
});

	}

	protected override void OnDisappearing()
	{
		base.OnDisappearing();
		if (BindingContext is RegisterViewModel viewModel)
		{
			viewModel.Cleanup();
		}
	}

}

using Masters_Summer_Project_CsharpPart2_Quiz.Helpers;
using Masters_Summer_Project_CsharpPart2_Quiz.ViewModels;

namespace Masters_Summer_Project_CsharpPart2_Quiz.Views;

public partial class EditQuizPage : ContentPage
{
	public EditQuizPage(EditQuizViewModel editQuizViewModel)
	{
		InitializeComponent();
		BindingContext = editQuizViewModel;

		AlertMessenger.RegisterForAlerts(this);
	}

	protected override void OnDisappearing()
	{
		base.OnDisappearing();
		AlertMessenger.UnregisterAlerts(this);
	}
}

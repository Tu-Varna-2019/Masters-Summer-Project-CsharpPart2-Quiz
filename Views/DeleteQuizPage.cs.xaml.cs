using Masters_Summer_Project_CsharpPart2_Quiz.Helpers;
using Masters_Summer_Project_CsharpPart2_Quiz.ViewModels;

namespace Masters_Summer_Project_CsharpPart2_Quiz.Views;

public partial class DeleteQuizPage : ContentPage
{
	public DeleteQuizPage(DeleteQuizViewModel deleteQuizViewModel)
	{
		InitializeComponent();
		BindingContext = deleteQuizViewModel;

		AlertMessenger.RegisterForAlerts(this);
	}

	protected override void OnDisappearing()
	{
		base.OnDisappearing();
		AlertMessenger.UnregisterAlerts(this);
	}
}

namespace Masters_Summer_Project_CsharpPart2_Quiz.ViewModels;

using Masters_Summer_Project_CsharpPart2_Quiz.Helpers;
using Masters_Summer_Project_CsharpPart2_Quiz.Models;
using Masters_Summer_Project_CsharpPart2_Quiz.Repositories;
using Masters_Summer_Project_CsharpPart2_Quiz.Services;
using Masters_Summer_Project_CsharpPart2_Quiz.Views;
using System.Windows.Input;

public class EditQuizViewModel : BaseViewModel
{
    public ICommand CreateQuizCommand { get; private set; }

    public EditQuizViewModel() : base()
    {
    }
    public EditQuizViewModel(UserRepository userRepository, INavigationService navigationService, User user) : base(userRepository, navigationService, user)
    {
        CreateQuizCommand = new Command(async () => await ExecuteCommand());
    }

    private async Task WhenQuizCreates()
    {
        await _navigationService.NavigateToAsync<ProfilePage>();
    }


    protected override async Task ExecuteCommand()
    {
        UXAnimation.IsLoading = true;
        try
        {

            await this.WhenQuizCreates();
        }
        catch (Exception ex)
        {
            AlertMessenger.SendMessage(ex.Message, false);
        }
        finally
        {
            UXAnimation.IsLoading = false;
        }
    }

    protected override bool CanExecuteCommand()
    {
        return !UXAnimation.IsLoading;
    }
}

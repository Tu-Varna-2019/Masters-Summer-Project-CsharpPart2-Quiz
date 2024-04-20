namespace Masters_Summer_Project_CsharpPart2_Quiz.ViewModels;

using Masters_Summer_Project_CsharpPart2_Quiz.Helpers;
using Masters_Summer_Project_CsharpPart2_Quiz.Models;
using Masters_Summer_Project_CsharpPart2_Quiz.Repositories;
using Masters_Summer_Project_CsharpPart2_Quiz.Services;
using Masters_Summer_Project_CsharpPart2_Quiz.Views;
using System.Windows.Input;

public class HomeViewModel : BaseViewModel
{
    public ICommand ProfileCommand { get; private set; }
    public ICommand NavigateToCreateQuiz { get; private set; }
    public ICommand NavigateToEditQuiz { get; private set; }
    public ICommand NavigateToDeleteQuiz { get; private set; }

    public HomeViewModel() : base()
    {
    }
    public HomeViewModel(UserRepository userRepository, INavigationService navigationService, User user) : base(userRepository, navigationService, user)
    {
        ProfileCommand = new Command(async () => await RouteToProfile());
        NavigateToCreateQuiz = new Command(async () => await RouteToCreateQuiz());
        NavigateToEditQuiz = new Command(async () => await RouteToEditQuiz());
        NavigateToDeleteQuiz = new Command(async () => await RouteToDeleteQuiz());
    }

    private async Task RouteToProfile()
    {
        await _navigationService.NavigateToAsync<ProfilePage>();
    }

    private async Task RouteToCreateQuiz()
    {
        await _navigationService.NavigateToAsync<CreateQuizPage>();
    }
    private async Task RouteToEditQuiz()
    {
        await _navigationService.NavigateToAsync<CreateQuizPage>();
    }
    private async Task RouteToDeleteQuiz()
    {
        await _navigationService.NavigateToAsync<CreateQuizPage>();
    }


    protected override async Task ExecuteCommand()
    {
        UXAnimation.IsLoading = true;
        try
        {
            // Nothing
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

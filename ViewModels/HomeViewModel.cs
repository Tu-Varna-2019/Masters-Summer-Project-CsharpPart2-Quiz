namespace Masters_Summer_Project_CsharpPart2_Quiz.ViewModels;

using Masters_Summer_Project_CsharpPart2_Quiz.Helpers;
using Masters_Summer_Project_CsharpPart2_Quiz.Repositories;
using Masters_Summer_Project_CsharpPart2_Quiz.Services;
using Masters_Summer_Project_CsharpPart2_Quiz.Views;
using System.Windows.Input;

public class HomeViewModel : BaseViewModel
{
    public ICommand ProfileCommand { get; private set; }
    private readonly UserService _userService;

    public HomeViewModel()
    {
    }
    public HomeViewModel(UserRepository userRepository, INavigationService navigationService)
    {
        _userService = new UserService(userRepository);
        _navigationService = navigationService;

        ProfileCommand = new Command(async () => await OnGoToProfileClicked());

    }

    private async Task OnGoToProfileClicked()
    {
        try
        {
            await _navigationService.NavigateToAsync<ProfilePage>();
        }
        catch (Exception ex)
        {
            AlertMessenger.SendMessage(ex.Message, false);
        }

    }


    protected override async Task ExecuteCommand()
    {
        UXAnimation.IsLoading = true;
        try
        {

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

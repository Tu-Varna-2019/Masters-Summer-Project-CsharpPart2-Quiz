namespace Masters_Summer_Project_CsharpPart2_Quiz.ViewModels;

using Masters_Summer_Project_CsharpPart2_Quiz.Helpers;
using Masters_Summer_Project_CsharpPart2_Quiz.Repositories;
using Masters_Summer_Project_CsharpPart2_Quiz.Services;

using System.Windows.Input;

public class HomeViewModel : BaseViewModel
{
    public ICommand RegisterCommand { get; private set; }
    private readonly UserService _userService;

    public HomeViewModel()
    {
    }
    public HomeViewModel(UserRepository userRepository)
    {
        _userService = new UserService(userRepository);
        RegisterCommand = new AutoRefreshCommand(ExecuteCommand, CanExecuteCommand, this);
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

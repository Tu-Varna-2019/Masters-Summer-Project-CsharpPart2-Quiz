using Masters_Summer_Project_CsharpPart2_Quiz.Models;
using System.Windows.Input;
using Masters_Summer_Project_CsharpPart2_Quiz.Helpers;
using Masters_Summer_Project_CsharpPart2_Quiz.Repositories;
using Masters_Summer_Project_CsharpPart2_Quiz.Services;
using Masters_Summer_Project_CsharpPart2_Quiz.Views;


namespace Masters_Summer_Project_CsharpPart2_Quiz.ViewModels;
public class LoginViewModel : BaseViewModel
{
    public ICommand LoginCommand { get; private set; }
    public ICommand GoToRegisterCommand { get; private set; }
    private readonly UserService _userService;
    private readonly User _user = new User();

    public string Email
    {
        get => _user.Email;
        set
        {
            _user.Email = value;
            OnPropertyChanged(nameof(LoginCommand));
        }
    }

    public string Password
    {
        get => _user.Password;
        set
        {
            _user.Password = value;
            OnPropertyChanged(nameof(LoginCommand));
        }
    }

    public LoginViewModel()
    {
    }
    public LoginViewModel(UserRepository userRepository, INavigationService navigationService)
    {
        _userService = new UserService(userRepository);
        _navigationService = navigationService;
        LoginCommand = new AutoRefreshCommand(ExecuteCommand, CanExecuteCommand, this);
        GoToRegisterCommand = new Command(async () => await OnGoToRegisterClicked());

    }


    protected override async Task ExecuteCommand()
    {
        IsLoading = true;
        try
        {
            await _userService.LoginUser(_user.Email, _user.Password);
            AlertMessenger.SendMessage($"User {Email} logged in successfully", true);
            await _navigationService.NavigateToAsync<HomePage>();
        }
        catch (Exception ex)
        {
            AlertMessenger.SendMessage(ex.Message, false);
        }
        finally
        {
            IsLoading = false;
        }
    }

    private async Task OnGoToRegisterClicked()
    {
        await _navigationService.NavigateToAsync<RegisterPage>();
    }

    protected override bool CanExecuteCommand()
    {
        return !IsLoading &&
               !string.IsNullOrWhiteSpace(_user.Email) &&
               !string.IsNullOrWhiteSpace(_user.Password);
        //    _userService.ValidateEmail(_user.Email) &&
        //    _userService.ValidatePassword(_user.Password);
    }
}

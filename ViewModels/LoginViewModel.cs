using System.Windows.Input;
using Masters_Summer_Project_CsharpPart2_Quiz.Helpers;
using Masters_Summer_Project_CsharpPart2_Quiz.Repositories;
using Masters_Summer_Project_CsharpPart2_Quiz.Services;
using Masters_Summer_Project_CsharpPart2_Quiz.Views;
using Masters_Summer_Project_CsharpPart2_Quiz.ViewModels.Presentations;
using Masters_Summer_Project_CsharpPart2_Quiz.Models;

namespace Masters_Summer_Project_CsharpPart2_Quiz.ViewModels;
public partial class LoginViewModel : BaseViewModel
{
    public ICommand LoginCommand { get; private set; }
    public ICommand GoToRegisterCommand { get; private set; }
    private UserProperty _userProperty;
    public UserProperty UserProperty
    {
        get => _userProperty;
        set
        {
            _userProperty = value;
            OnPropertyChanged(nameof(UserProperty));
        }
    }

    public LoginViewModel() : base()
    {
    }
    public LoginViewModel(UserRepository userRepository, INavigationService navigationService, User user) : base(userRepository, navigationService, user)
    {
        LoginCommand = new AutoRefreshCommand(ExecuteCommand, CanExecuteCommand, this);
        _userProperty = new UserProperty();

        _userProperty.PropertyChanged += (s, e) => ((AutoRefreshCommand)LoginCommand).RaiseCanExecuteChanged();
        GoToRegisterCommand = new Command(async () => await OnGoToRegisterClicked());
    }

    protected override async Task ExecuteCommand()
    {
        UXAnimation.IsLoading = true;
        try
        {
            await Task.Delay(2000);
            var loggedUser = await _userService.LoginUser(UserProperty.Email, UserProperty.Password);
            _user.Username = loggedUser.Username;
            _user.Email = loggedUser.Email;
            _user.Password = "";
            AlertMessenger.SendMessage($"User {_user.Email} logged in successfully", true);
            await _navigationService.NavigateToAsync<HomePage>();
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

    private async Task OnGoToRegisterClicked()
    {
        await _navigationService.NavigateToAsync<RegisterPage>();
    }

    protected override bool CanExecuteCommand()
    {
        return !UXAnimation.IsLoading &&
               !string.IsNullOrWhiteSpace(UserProperty.Email) &&
               !string.IsNullOrWhiteSpace(UserProperty.Password);
        //    _userService.ValidateEmail(_user.Email) &&
        //    _userService.ValidatePassword(_user.Password);
    }
}

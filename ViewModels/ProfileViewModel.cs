namespace Masters_Summer_Project_CsharpPart2_Quiz.ViewModels;

using System.Windows.Input;
using Masters_Summer_Project_CsharpPart2_Quiz.Helpers;
using Masters_Summer_Project_CsharpPart2_Quiz.Models;
using Masters_Summer_Project_CsharpPart2_Quiz.Repositories;
using Masters_Summer_Project_CsharpPart2_Quiz.Services;
using Masters_Summer_Project_CsharpPart2_Quiz.ViewModels.Presentations;
using Masters_Summer_Project_CsharpPart2_Quiz.Views;

public partial class ProfileViewModel : BaseViewModel
{
    public ICommand ChangeUsernameAction { get; private set; }
    public ICommand ChangeEmailCommand { get; private set; }
    public ICommand ChangePasswordCommand { get; private set; }
    public ICommand LogOutCommand { get; private set; }

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
    public ProfileViewModel() : base()
    {
    }
    public ProfileViewModel(UserRepository userRepository, INavigationService navigationService, User user) : base(userRepository, navigationService, user)
    {
        ChangeUsernameAction = new Command(async () => await WhenUsernameChanges());
        ChangeEmailCommand = new AutoRefreshCommand(ExecuteCommand, CanExecuteCommand, this);
        ChangePasswordCommand = new AutoRefreshCommand(ExecuteCommand, CanExecuteCommand, this);

        LogOutCommand = new Command(async () => await OnGoToLoginClicked());
    }

    private async Task OnGoToLoginClicked()
    {
        await _navigationService.NavigateToAsync<LoginPage>();
    }

    private async Task WhenUsernameChanges()
    {

        // TODO: Add an implementation
    }


    protected override async Task ExecuteCommand()
    {
        UXAnimation.IsLoading = true;
        try
        {
            await Task.Delay(2000);
            await _userService.RegisterUser(UserProperty.User);
            AlertMessenger.SendMessage($"User {UserProperty.Username} registered successfully", true);
            await _navigationService.NavigateToAsync<LoginPage>();
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
        return !UXAnimation.IsLoading && !string.IsNullOrWhiteSpace(UserProperty.Username) &&
               !string.IsNullOrWhiteSpace(UserProperty.Email) &&
               !string.IsNullOrWhiteSpace(UserProperty.Password);
        //_user.Password == _confirmPassword;
        //    _userService.ValidateEmail(_user.Email) &&
        //    _userService.ValidatePassword(_user.Password);
    }

}


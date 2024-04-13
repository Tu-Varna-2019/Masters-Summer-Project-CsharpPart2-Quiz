namespace Masters_Summer_Project_CsharpPart2_Quiz.ViewModels;

using Masters_Summer_Project_CsharpPart2_Quiz.Helpers;
using Masters_Summer_Project_CsharpPart2_Quiz.Repositories;
using Masters_Summer_Project_CsharpPart2_Quiz.Services;
using Masters_Summer_Project_CsharpPart2_Quiz.ViewModels.Presentations;
using Masters_Summer_Project_CsharpPart2_Quiz.Views;
using System.Windows.Input;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

public class ProfileViewModel : BaseViewModel
{
    public ICommand ChangeUsernameCommand { get; private set; }
    public ICommand ChangeEmailCommand { get; private set; }
    public ICommand ChangePasswordCommand { get; private set; }
    public ICommand LogOutCommand { get; private set; }
    private readonly UserService _userService;
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
    public ProfileViewModel()
    {
    }
    public ProfileViewModel(UserRepository userRepository, INavigationService navigationService)
    {

        _userService = new UserService(userRepository);
        _navigationService = navigationService;

        ChangeUsernameCommand = new AutoRefreshCommand(ExecuteCommand, CanExecuteCommand, this);
        ChangeEmailCommand = new AutoRefreshCommand(ExecuteCommand, CanExecuteCommand, this);
        ChangePasswordCommand = new AutoRefreshCommand(ExecuteCommand, CanExecuteCommand, this);

        _userProperty = new UserProperty();

        //_userProperty.PropertyChanged += (s, e) => ((AutoRefreshCommand)RegisterCommand).RaiseCanExecuteChanged();
        LogOutCommand = new Command(async () => await OnGoToLoginClicked());
    }

    private async Task OnGoToLoginClicked()
    {
        await _navigationService.NavigateToAsync<LoginPage>();
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

    private async void ShowDialogButton_Clicked(object sender, EventArgs e)
    {
        // Create a new dialog
        var dialog = new Dialog();

        // Add dialog content
        dialog.Content = new StackLayout
        {
            Children =
                {
                    new Entry { Placeholder = "Username" },
                    new Entry { Placeholder = "Password", IsPassword = true }
                }
        };

        // Add dialog buttons
        dialog.Buttons.Add(new ImageButton { Source = "confirm.png" }); // Add a confirm button
        dialog.Buttons.Add(new ImageButton { Source = "cancel.png" }); // Add a cancel button

        // Show the dialog
        await dialog.ShowAsync();
    }
}
}

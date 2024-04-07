namespace Masters_Summer_Project_CsharpPart2_Quiz.ViewModels;

using Masters_Summer_Project_CsharpPart2_Quiz.Helpers;
using Masters_Summer_Project_CsharpPart2_Quiz.Repositories;
using Masters_Summer_Project_CsharpPart2_Quiz.Services;
using Masters_Summer_Project_CsharpPart2_Quiz.ViewModels.Presentations;
using Masters_Summer_Project_CsharpPart2_Quiz.Views;
using System.Windows.Input;

public class RegisterViewModel : BaseViewModel
{
	public ICommand RegisterCommand { get; private set; }
	public ICommand GoToLoginClicked { get; private set; }
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
	public RegisterViewModel()
	{
	}
	public RegisterViewModel(UserRepository userRepository, INavigationService navigationService)
	{

		_userService = new UserService(userRepository);
		_navigationService = navigationService;

		RegisterCommand = new AutoRefreshCommand(ExecuteCommand, CanExecuteCommand, this);
		_userProperty = new UserProperty();

		_userProperty.PropertyChanged += (s, e) => ((AutoRefreshCommand)RegisterCommand).RaiseCanExecuteChanged();
		GoToLoginClicked = new Command(async () => await OnGoToLoginClicked());
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
}

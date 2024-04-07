namespace Masters_Summer_Project_CsharpPart2_Quiz.ViewModels;

using Masters_Summer_Project_CsharpPart2_Quiz.Helpers;
using Masters_Summer_Project_CsharpPart2_Quiz.Models;
using Masters_Summer_Project_CsharpPart2_Quiz.Repositories;
using Masters_Summer_Project_CsharpPart2_Quiz.Services;
using Masters_Summer_Project_CsharpPart2_Quiz.Views;
using System.Windows.Input;

public class RegisterViewModel : BaseViewModel
{
	public ICommand RegisterCommand { get; private set; }
	public ICommand GoToLoginClicked { get; private set; }
	private readonly UserService _userService;
	private readonly User _user = new User();
	private string _confirmPassword = string.Empty;

	public string ConfirmPassword
	{
		get => _confirmPassword;
		set
		{
			_confirmPassword = value;
			OnPropertyChanged(nameof(RegisterCommand));
		}
	}

	public string Username
	{
		get => _user.Username;
		set { _user.Username = value; OnPropertyChanged(nameof(RegisterCommand)); }
	}

	public string Email
	{
		get => _user.Email;
		set
		{
			_user.Email = value;
			OnPropertyChanged(nameof(RegisterCommand));
		}
	}

	public string Password
	{
		get => _user.Password;
		set
		{
			_user.Password = value;
			OnPropertyChanged(nameof(RegisterCommand));
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
		GoToLoginClicked = new Command(async () => await OnGoToLoginClicked());
	}

	private async Task OnGoToLoginClicked()
	{
		await _navigationService.NavigateToAsync<LoginPage>();
	}


	protected override async Task ExecuteCommand()
	{
		IsLoading = true;
		try
		{
			await _userService.RegisterUser(_user);
			AlertMessenger.SendMessage($"User {Username} registered successfully", true);
			await _navigationService.NavigateToAsync<LoginPage>();
		}
		catch (Exception ex)
		{
			AlertMessenger.SendMessage(ex.ToString(), false);
		}
		finally
		{
			IsLoading = false;
		}
	}

	protected override bool CanExecuteCommand()
	{

		return !IsLoading && !string.IsNullOrWhiteSpace(_user.Username) &&
			   !string.IsNullOrWhiteSpace(_user.Email) &&
			   !string.IsNullOrWhiteSpace(_user.Password) &&
			   _user.Password == _confirmPassword;
		//    _userService.ValidateEmail(_user.Email) &&
		//    _userService.ValidatePassword(_user.Password);
	}
}

namespace Masters_Summer_Project_CsharpPart2_Quiz.ViewModels;

using Masters_Summer_Project_CsharpPart2_Quiz.Helpers;
using Masters_Summer_Project_CsharpPart2_Quiz.Models;
using Masters_Summer_Project_CsharpPart2_Quiz.Repositories;
using Masters_Summer_Project_CsharpPart2_Quiz.Services;

using System.Windows.Input;

public class RegisterViewModel : BaseViewModel
{
	private bool _isLoading = false;
	public bool IsLoading
	{
		get => _isLoading;
		set { if (_isLoading != value) _isLoading = value; OnPropertyChanged(nameof(IsLoading)); }
	}

	public ICommand RegisterCommand { get; private set; }
	private readonly UserService _userService;
	private readonly User _user = new User();

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
	public RegisterViewModel(UserRepository userRepository)
	{
		_userService = new UserService(userRepository);
		RegisterCommand = new AutoRefreshCommand(ExecuteRegisterCommand, CanExecuteRegister, this);
	}


	private async Task ExecuteRegisterCommand()
	{
		IsLoading = true;
		try
		{
			await _userService.RegisterUser(_user);
			AlertMessenger.SendMessage($"User {Username} registered successfully", true);
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

	private bool CanExecuteRegister()
	{
		return !IsLoading && !string.IsNullOrWhiteSpace(_user.Username) &&
			   !string.IsNullOrWhiteSpace(_user.Email) &&
			   !string.IsNullOrWhiteSpace(_user.Password);
	}
}

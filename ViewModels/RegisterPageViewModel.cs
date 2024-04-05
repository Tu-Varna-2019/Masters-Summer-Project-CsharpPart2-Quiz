namespace Masters_Summer_Project_CsharpPart2_Quiz.ViewModels;

using CommunityToolkit.Mvvm.Messaging;
using Masters_Summer_Project_CsharpPart2_Quiz.Helpers;
using Masters_Summer_Project_CsharpPart2_Quiz.Models;
using Masters_Summer_Project_CsharpPart2_Quiz.Repositories;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;


public class RegisterViewModel : INotifyPropertyChanged
{
	public ICommand RegisterCommand { get; private set; }
	private readonly UserRepository _userRepository;
	private User _user = new User();
	public event PropertyChangedEventHandler? PropertyChanged;

	protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

	public string Username
	{
		get => _user.Username;
		set
		{
			_user.Username = value;
			OnPropertyChanged();
		}
	}

	public string Email
	{
		get => _user.Email;
		set
		{
			_user.Email = value;
			OnPropertyChanged();
		}
	}

	public string Password
	{
		get => _user.Password;
		set
		{
			_user.Password = value;
			OnPropertyChanged();
		}
	}

	public RegisterViewModel()
	{
		RegisterCommand = new Command(async () => await ExecuteRegisterCommand());
	}
	public RegisterViewModel(UserRepository userRepository)
	{
		try
		{
			_userRepository = userRepository;
			RegisterCommand = new Command(async () => await ExecuteRegisterCommand());
		}
		catch (Exception ex)
		{
			AlertMessenger.SendMessage(ex.ToString(), false);
		}
	}

	private async Task ExecuteRegisterCommand()
	{
		try
		{
			await _userRepository.CreateCommand(_user);

			AlertMessenger.SendMessage("User added successfully", true);
		}
		catch (Exception ex)
		{
			AlertMessenger.SendMessage(ex.ToString(), false);
		}
	}

	public void Cleanup()
	{
		WeakReferenceMessenger.Default.UnregisterAll(this);
	}
}

namespace Masters_Summer_Project_CsharpPart2_Quiz.ViewModels;

using Masters_Summer_Project_CsharpPart2_Quiz.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Masters_Summer_Project_CsharpPart2_Quiz.Services;


internal class RegisterViewModel : INotifyPropertyChanged, IQueryAttributable

{

	private User _user;
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

	public ICommand RegisterCommand { get; private set; }

	public RegisterViewModel()
	{
		_user = new User();
		RegisterCommand = new Command(ExecuteRegisterCommand);
	}

	private async void ExecuteRegisterCommand()
	{
		var connectionString = "Host=geodb.cpm2u4caeypo.eu-west-1.rds.amazonaws.com;Database=quiz;Username=postgres;Password=<p2W7nw^%bTx3eQ~q*8LE<VWi+ZcXQVf49pUy@";

		var dbService = new QuizDBService(connectionString);

		try
		{
			await dbService.AddUserAsync(_user);
			MessagingCenter.Send(this, "RegisterSuccess", "User added successfully");
		}
		catch (Exception ex)
		{
			MessagingCenter.Send(this, "RegisterError", ex.Message);
		}
	}



	public RegisterViewModel(User user)
	{
		_user = user;
	}

	public void ApplyQueryAttributes(IDictionary<string, object> query)
	{
		throw new NotImplementedException();
	}
}

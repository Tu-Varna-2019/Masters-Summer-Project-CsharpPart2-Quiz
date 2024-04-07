using Masters_Summer_Project_CsharpPart2_Quiz.Models;

namespace Masters_Summer_Project_CsharpPart2_Quiz.ViewModels.Presentations;

public class UserProperty : PropertyChange
{
	public readonly User _user = new User();
	public User User => _user;

	private string _confirmPassword = string.Empty;


	public string ConfirmPassword
	{
		get => _confirmPassword;
		set
		{
			_confirmPassword = value;
			OnPropertyChanged(nameof(ConfirmPassword));
		}
	}

	public string Username
	{
		get => _user.Username;
		set { _user.Username = value; OnPropertyChanged(nameof(Username)); }
	}

	public string Email
	{
		get => _user.Email;
		set
		{
			_user.Email = value;
			OnPropertyChanged(nameof(Email));
		}
	}

	public string Password
	{
		get => _user.Password;
		set
		{
			_user.Password = value;
			OnPropertyChanged(nameof(Password));
		}
	}

	public UserProperty()
	{
	}

}

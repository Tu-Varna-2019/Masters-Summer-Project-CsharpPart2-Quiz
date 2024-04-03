namespace Masters_Summer_Project_CsharpPart2_Quiz.Models;

public class User
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public User()
    {
        Username = "Username";
        Email = "Email";
        Password = "Password";
    }

    public User(string username, string email, string password)
    {
        Username = username;
        Email = email;
        Password = password;
    }
}

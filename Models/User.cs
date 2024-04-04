namespace Masters_Summer_Project_CsharpPart2_Quiz.Models;

public class User
{
    private int _id;
    private string _username;
    private string _email;
    private string _password;

    public int Id { get => _id; set => _id = value; }
    public string Username { get => _username; set => _username = value; }
    public string Email { get => _email; set => _email = value; }
    public string Password { get => _password; set => _password = value; }

    public User()
    {
        _username = "";
        _email = "";
        _password = "";
    }

    public User(string id, string username, string email, string password)
    {
        _id = int.Parse(id);
        _username = username;
        _email = email;
        _password = password;
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Masters_Summer_Project_CsharpPart2_Quiz.Models;

[Table("user")]
public class User
{
    private int _id;
    private string _username;
    private string _email;
    private string _password;

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get => _id; set => _id = value; }

    [Required]
    [Column("username")]
    [StringLength(50)]
    public string Username { get => _username; set => _username = value; }

    [Required]
    [Column("email")]
    [StringLength(100)]
    public string Email { get => _email; set => _email = value; }
    [Required]
    [Column("password")]
    [StringLength(255)]
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

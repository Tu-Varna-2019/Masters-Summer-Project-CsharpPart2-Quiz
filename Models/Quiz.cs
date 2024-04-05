
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Masters_Summer_Project_CsharpPart2_Quiz.Models;

[Table("quiz")]
public class Quiz
{
    private int _id;
    private string _title;
    private List<Question> _questions;
    private int _userId;
    private User _user;

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }
    [Required]
    [Column("title")]
    public string Title { get; set; }

    [Column("questions")]
    public List<Question> Questions { get; set; } = new List<Question>();
    [Column("user_id")]
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public User User { get; set; }
}

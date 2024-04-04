
namespace Masters_Summer_Project_CsharpPart2_Quiz.Models;

public class Quiz
{
    public int Id { get; set; }
    public string Title { get; set; }
    public List<Question> Questions { get; set; } = new List<Question>();
    public int UserId { get; set; }
    public User User { get; set; }
}

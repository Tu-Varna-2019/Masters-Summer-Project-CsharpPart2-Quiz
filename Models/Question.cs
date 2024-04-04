namespace Masters_Summer_Project_CsharpPart2_Quiz.Models;

public class Question
{
    public int Id { get; set; }
    public string Text { get; set; }
    public List<Answer> Answers { get; set; } = new List<Answer>();
    public int QuizId { get; set; }
    public Quiz Quiz { get; set; }
}

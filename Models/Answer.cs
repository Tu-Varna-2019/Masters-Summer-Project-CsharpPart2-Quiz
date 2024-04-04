namespace Masters_Summer_Project_CsharpPart2_Quiz.Models;

public class Answer
{
    public int Id { get; set; }
    public string Text { get; set; }
    public bool IsCorrect { get; set; }
    public int QuestionId { get; set; }
    public Question Question { get; set; }
}

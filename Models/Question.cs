using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Masters_Summer_Project_CsharpPart2_Quiz.Models;

[Table("question")]
public class Question
{
    [Key]
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [Column("text")]
    public string Text { get; set; }

    [Column("answers")]
    public List<Answer> Answers { get; set; } = new List<Answer>();

    [Column("quiz_id")]

    public int QuizId { get; set; }
    [ForeignKey("QuizId")]
    public Quiz Quiz { get; set; }
}

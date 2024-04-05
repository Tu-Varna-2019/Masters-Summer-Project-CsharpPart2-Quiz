using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Masters_Summer_Project_CsharpPart2_Quiz.Models;

[Table("answer")]
public class Answer
{
    [Key]
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [Column("text")]
    public string Text { get; set; }

    [Column("is_correct")]
    public bool IsCorrect { get; set; }

    [Column("question_id")]
    public int QuestionId { get; set; }

    [ForeignKey("QuestionId")]
    public Question Question { get; set; }
}

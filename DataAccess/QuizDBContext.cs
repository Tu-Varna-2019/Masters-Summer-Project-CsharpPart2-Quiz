using Masters_Summer_Project_CsharpPart2_Quiz.Models;
using Microsoft.EntityFrameworkCore;
namespace Masters_Summer_Project_CsharpPart2_Quiz.DataAccess;
public class QuizDBContext : DbContext
{

    public DbSet<User> Users { get; set; }
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }

    public QuizDBContext(DbContextOptions<QuizDBContext> options) : base(options)
    {
    }
}

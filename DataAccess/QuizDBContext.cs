using Npgsql;
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
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
                {
                    entity.ToTable("User");

                    entity.HasKey(e => e.Id);
                    entity.Property(e => e.Id).HasColumnName("id");

                    entity.Property(e => e.Username)
                        .HasColumnName("username")
                        .IsRequired()
                        .HasMaxLength(50);

                    entity.Property(e => e.Email)
                        .HasColumnName("email")
                        .IsRequired()
                        .HasMaxLength(100);

                    entity.Property(e => e.Password)
                        .HasColumnName("password")
                        .IsRequired()
                        .HasMaxLength(255);
                });
    }
}

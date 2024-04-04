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

    private string _databaseHost;
    private string _username;
    private string _password;
    private string _connectionString;
    private const string databbaseName = "quiz";




    public QuizDBContext(DbContextOptions<QuizDBContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        _databaseHost = Environment.GetEnvironmentVariable("POSTGRE_HOST") ?? throw new ArgumentException("Environment variable 'POSTGRE_HOST' is not set.");

        _username = Environment.GetEnvironmentVariable("POSTGRE_USERNAME") ?? throw new ArgumentException("Environment variable 'POSTGRE_USERNAME' is not set.");
        _password = Environment.GetEnvironmentVariable("POSTGRE_PASSWORD") ?? throw new ArgumentException("Environment variable 'POSTGRE_PASSWORD' is not set.");

        _connectionString = $"Host={_databaseHost};Username={_username};Password={_password};Database={databbaseName}";

        optionsBuilder.UseNpgsql(_connectionString);
    }


    public async Task AddUserAsync(User user)
    {
        await using var conn = new NpgsqlConnection(_connectionString);
        await conn.OpenAsync();

        var cmd = new NpgsqlCommand("INSERT INTO \"user\" (username, email, password) VALUES (@username, @email, @password)", conn);
        cmd.Parameters.AddWithValue("username", user.Username);
        cmd.Parameters.AddWithValue("email", user.Email);
        cmd.Parameters.AddWithValue("password", user.Password); // Consider hashing the password

        await cmd.ExecuteNonQueryAsync();
    }
}

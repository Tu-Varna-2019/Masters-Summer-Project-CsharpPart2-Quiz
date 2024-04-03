using Npgsql;
using System.Threading.Tasks;
using Masters_Summer_Project_CsharpPart2_Quiz.Models;
namespace Masters_Summer_Project_CsharpPart2_Quiz.Services;

public class QuizDBService
{
    private readonly string _connectionString;

    public QuizDBService(string connectionString)
    {
        _connectionString = connectionString;
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

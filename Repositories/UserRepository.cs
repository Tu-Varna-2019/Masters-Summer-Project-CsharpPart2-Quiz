using Masters_Summer_Project_CsharpPart2_Quiz.Models;
using Masters_Summer_Project_CsharpPart2_Quiz.DataAccess;

namespace Masters_Summer_Project_CsharpPart2_Quiz.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{

    public UserRepository(QuizDBContext context) : base(context)
    {
    }

    public User GetByEmail(string email)
    {
        return _context.Users.FirstOrDefault(u => u.Email == email);
    }

    public bool ValidateUserCreds(string email, string password)
    {
        return _context.Users.Any(u => u.Email == email && u.Password == password);
    }
    public IEnumerable<User> SearchUsers(string searchTerm)
    {
        return _context.Set<User>()
            .Where(user => user.Username.Contains(searchTerm) || user.Email.Contains(searchTerm))
            .ToList();
    }
}

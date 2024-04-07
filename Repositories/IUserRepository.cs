using Masters_Summer_Project_CsharpPart2_Quiz.Models;

namespace Masters_Summer_Project_CsharpPart2_Quiz.Repositories;

public interface IUserRepository : IRepository<User>
{
    public User GetByEmail(string email);
    public bool ValidateUserCreds(string email, string password);
    public List<User> GetUsers();

}


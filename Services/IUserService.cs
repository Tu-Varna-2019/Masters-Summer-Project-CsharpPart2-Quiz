using Masters_Summer_Project_CsharpPart2_Quiz.Models;

namespace Masters_Summer_Project_CsharpPart2_Quiz.Services
{
    public interface IUserService
    {
        public Task<User> RegisterUser(User user);
        public Task<User> LoginUser(string email, string password);
    }
}

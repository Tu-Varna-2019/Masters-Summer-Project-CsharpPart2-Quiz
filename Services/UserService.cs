using Masters_Summer_Project_CsharpPart2_Quiz.Helpers;
using Masters_Summer_Project_CsharpPart2_Quiz.Models;
using Masters_Summer_Project_CsharpPart2_Quiz.Repositories;

namespace Masters_Summer_Project_CsharpPart2_Quiz.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> RegisterUser(User user)
    {
        // Check if user already exists
        if (_userRepository.GetByEmail(user.Email) == null)
        {

            // Hash pasword
            user.Password = MaskData.HashPasword(user.Password);

            return await _userRepository.CreateCommand(user);
        }

        throw new ArgumentException($"User with email {user.Email} already exists");


    }

    public async Task<User> LoginUser(string email, string password)
    {
        User user = _userRepository.GetByEmail(email);

        if (_userRepository.ValidateUserCreds(email, MaskData.HashPasword(password)))
        {
            return user;
        }
        throw new ArgumentException("Invalid credentials");
    }

}

using Masters_Summer_Project_CsharpPart2_Quiz.Helpers;
using Masters_Summer_Project_CsharpPart2_Quiz.Models;
using Masters_Summer_Project_CsharpPart2_Quiz.Repositories;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

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

        if (_userRepository.ValidateUserCreds(email, password))
        {
            return _userRepository.GetByEmail(email);
        }
        throw new ArgumentException("Invalid credentials! ");
    }

    public bool ValidateEmail(string email)
    /// <summary>
    /// Validate email address
    /// </summary>
    {
        return new EmailAddressAttribute().IsValid(email);
    }

    public bool ValidatePassword(string password)
    /// <summary>
    /// Validate password with at least 1 uppercase, 1 lowercase, 1 special character and 8 characters long
    /// </summary>
    {
        return Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\W).{8,}$");
    }

}

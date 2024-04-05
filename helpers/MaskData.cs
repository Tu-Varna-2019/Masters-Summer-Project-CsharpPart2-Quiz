namespace Masters_Summer_Project_CsharpPart2_Quiz.Helpers;

public class MaskData
{
    public static string HashPasword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public static bool VerifyPassword(string password, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }
}

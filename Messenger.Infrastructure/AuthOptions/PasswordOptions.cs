using MessengerX.Domain.Shared.Types;
using System.Security.Cryptography;
using System.Text;

namespace MessengerX.Infrastructure.AuthOptions;

public static class PasswordOptions
{
    public static PasswordType CreatePasswordHash(this string password)
    {
        try
        {
            var hmac = new HMACSHA512();

            return new PasswordType()
            {
                Salt = hmac.Key,
                Hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password))
            };
        }
        catch (Exception)
        {
            throw new Exception("Failed to create hash password");
        }
    }

    public static bool VerifyPasswordHash(string password, PasswordType targetPassword)
    {
        try
        {
            var hmac = new HMACSHA512(targetPassword.Salt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(targetPassword.Hash);
        }
        catch (Exception)
        {
            throw new Exception("Failed to verify hash password");
        }
    }
}

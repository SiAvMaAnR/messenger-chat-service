using System.Security.Cryptography;
using System.Text;
using MessengerX.Domain.Exceptions.BusinessExceptions;
using MessengerX.Domain.Shared.Models;

namespace MessengerX.Infrastructure.AuthOptions;

public static class PasswordOptions
{
    public static Password CreatePasswordHash(string password)
    {
        try
        {
            var hmac = new HMACSHA512();

            return new Password()
            {
                Salt = hmac.Key,
                Hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password))
            };
        }
        catch (Exception)
        {
            throw new PasswordException("Failed to create hash password");
        }
    }

    public static bool VerifyPasswordHash(string password, Password targetPassword)
    {
        try
        {
            var hmac = new HMACSHA512(targetPassword.Salt);
            byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(targetPassword.Hash);
        }
        catch (Exception)
        {
            throw new PasswordException("Failed to verify hash password");
        }
    }
}

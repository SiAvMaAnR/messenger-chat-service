using MessengerX.Domain.Entities.Users;
using MessengerX.Domain.Shared.Models;
using MessengerX.Infrastructure.AuthOptions;
using Microsoft.EntityFrameworkCore;

namespace MessengerX.Persistence.Seeds.DefaultUsers;

internal static partial class DefaultUsersSeed
{
    public static void CreateUsers(this ModelBuilder modelBuilder)
    {
        var users = new[]
        {
            new
            {
                Id = 2,
                Email = "user@user.com",
                Login = "User",
                Password = "Sosnova61S"
            }
        };

        IEnumerable<User> userList = users.Select(user =>
        {
            Password password = PasswordOptions.CreatePasswordHash(user.Password);

            return new User()
            {
                Id = user.Id,
                Email = user.Email,
                Login = user.Login,
                PasswordHash = password.Hash,
                PasswordSalt = password.Salt,
                Birthday = new DateOnly(2002, 1, 9)
            };
        });

        modelBuilder.Entity<User>().HasData(userList.ToArray());
    }
}

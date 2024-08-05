using Messenger.Domain.Entities.Users;
using Messenger.Domain.Services;
using Messenger.Domain.Shared.Models;
using Messenger.Persistence.DBContext;

namespace Messenger.Persistence.Seeds.DefaultUsers;

internal static partial class DefaultUsersSeed
{
    public static void CreateUsers(EFContext eFContext)
    {
        if (eFContext.Users.Any())
        {
            throw new InvalidOperationException("Users already exists");
        }

        var users = new[]
        {
            new
            {
                Email = "user@user.com",
                Login = "User",
                Password = "Sosnova61S"
            }
        };

        IEnumerable<User> userList = users.Select(user =>
        {
            Password password = AuthBS.CreatePasswordHash(user.Password);

            return new User(user.Email, user.Login, password.Hash, password.Salt)
            {
                Birthday = new DateOnly(2002, 1, 9)
            };
        });

        eFContext.Users.AddRange(userList);
        eFContext.SaveChanges();
    }
}

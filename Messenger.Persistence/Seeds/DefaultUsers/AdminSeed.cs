using MessengerX.Domain.Entities.Admins;
using MessengerX.Domain.Shared.Models;
using MessengerX.Infrastructure.AuthOptions;
using MessengerX.Persistence.DBContext;

namespace MessengerX.Persistence.Seeds.DefaultUsers;

internal static partial class DefaultUsersSeed
{
    public static void CreateAdmins(EFContext eFContext)
    {
        if (eFContext.Admins.Any())
        {
            throw new InvalidOperationException("Admins already exists");
        }

        var admins = new[]
        {
            new
            {
                Email = "admin@admin.com",
                Login = "Admin",
                Password = "Sosnova61S"
            }
        };

        IEnumerable<Admin> adminList = admins.Select(admin =>
        {
            Password password = PasswordOptions.CreatePasswordHash(admin.Password);

            return new Admin(admin.Email, admin.Login, password.Hash, password.Salt);
        });

        eFContext.Admins.AddRange(adminList);
        eFContext.SaveChanges();
    }
}

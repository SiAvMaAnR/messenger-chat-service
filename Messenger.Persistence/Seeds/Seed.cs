using MessengerX.Persistence.Seeds.DefaultUsers;
using Microsoft.EntityFrameworkCore;

namespace MessengerX.Persistence.Seeds;

internal static class Seed
{
    public static void ApplySeeds(this ModelBuilder modelBuilder)
    {
        modelBuilder.CreateAdmins();
    }
}

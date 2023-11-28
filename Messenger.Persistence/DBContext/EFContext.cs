using MessengerX.Domain.Entities.Accounts;
using MessengerX.Domain.Entities.Admins;
using MessengerX.Domain.Entities.Users;
using MessengerX.Persistence.EntityConfigurations;
using MessengerX.Persistence.Seeds;
using Microsoft.EntityFrameworkCore;

namespace MessengerX.Persistence.DBContext;

public class EFContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Admin> Admins { get; set; }

    public EFContext(DbContextOptions<EFContext> options)
        : base(options)
    {
        // Database.EnsureDeleted();
        // Database.EnsureCreated();
        Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AccountConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new AdminConfiguration());

        modelBuilder.ApplySeeds();

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
}

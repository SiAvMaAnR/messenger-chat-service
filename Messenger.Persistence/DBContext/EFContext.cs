using MessengerX.Domain.Entities.Accounts;
using MessengerX.Domain.Entities.Users;
using MessengerX.Persistence.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace MessengerX.Persistence.DBContext;

public class EFContext : DbContext
{
    public DbSet<Account> Accounts { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    public EFContext(DbContextOptions<EFContext> options)
        : base(options)
    {
        Database.EnsureCreated();
        // Database.EnsureDeleted();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AccountConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
}

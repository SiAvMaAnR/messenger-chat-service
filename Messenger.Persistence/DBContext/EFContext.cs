using MessengerX.Persistence.EntityConfigurations;
using MessengerX.Domain.Entities.Accounts;
using MessengerX.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace MessengerX.Persistence.DBContext;

public class EFContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Account> Accounts { get; set; } = null!;

    public EFContext(DbContextOptions<EFContext> options)
        : base(options)
    {
        // Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new AccountConfiguration());

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
}

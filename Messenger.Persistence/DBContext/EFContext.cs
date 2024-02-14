using MessengerX.Domain.Entities.Accounts;
using MessengerX.Domain.Entities.Admins;
using MessengerX.Domain.Entities.Channels;
using MessengerX.Domain.Entities.Messages;
using MessengerX.Domain.Entities.RefreshTokens;
using MessengerX.Domain.Entities.Users;
using MessengerX.Persistence.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace MessengerX.Persistence.DBContext;

public class EFContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<Channel> Channels { get; set; }
    public DbSet<Message> Message { get; set; }

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
        modelBuilder.ApplyConfiguration(new RefreshTokenConfiguration());
        modelBuilder.ApplyConfiguration(new ChannelConfiguration());
        modelBuilder.ApplyConfiguration(new MessageConfiguration());

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
}

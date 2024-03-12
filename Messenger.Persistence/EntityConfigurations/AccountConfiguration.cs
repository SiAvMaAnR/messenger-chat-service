using MessengerX.Domain.Entities.Accounts;
using MessengerX.Domain.Entities.Channels.Messages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MessengerX.Persistence.EntityConfigurations;

internal class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.UseTphMappingStrategy();
        builder.HasIndex(account => account.Email).IsUnique();
        builder.Property(account => account.Email).IsRequired();
        builder.Property(account => account.PasswordHash).IsRequired();
        builder.Property(account => account.PasswordSalt).IsRequired();
        builder.Property(account => account.Role).IsRequired();
        builder.HasIndex(account => account.Role);

        builder
            .HasMany(account => account.ReadMessages)
            .WithMany(message => message.ReadAccounts)
            .UsingEntity<Dictionary<string, object>>(
                "AccountMessage",
                j => j.HasOne<Message>().WithMany().OnDelete(DeleteBehavior.Cascade),
                j => j.HasOne<Account>().WithMany().OnDelete(DeleteBehavior.Restrict)
            );
    }
}

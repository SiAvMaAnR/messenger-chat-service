using MessengerX.Domain.Entities.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MessengerX.Persistence.EntityConfigurations;

internal class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.UseTpcMappingStrategy();
        builder.HasIndex(account => account.Email).IsUnique();
        builder.Property(account => account.Email).IsRequired();
        builder.Property(account => account.PasswordHash).IsRequired();
        builder.Property(account => account.PasswordSalt).IsRequired();
        builder.Property(account => account.Role).IsRequired();
        builder.HasIndex(account => account.Role);
    }
}

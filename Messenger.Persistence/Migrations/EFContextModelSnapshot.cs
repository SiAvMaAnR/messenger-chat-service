using MessengerX.Persistence.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

#nullable disable

namespace Messenger.Persistence.Migrations;

[DbContext(typeof(EFContext))]
partial class EFContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
        modelBuilder
            .HasAnnotation("ProductVersion", "8.0.0")
            .HasAnnotation("Relational:MaxIdentifierLength", 128);

        SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

        modelBuilder.HasSequence("AccountSequence");

        modelBuilder.Entity("MessengerX.Domain.Entities.Accounts.Account", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasDefaultValueSql("NEXT VALUE FOR [AccountSequence]");

                SqlServerPropertyBuilderExtensions.UseSequence(b.Property<int>("Id"));

                b.Property<DateTime?>("CreatedAt")
                    .HasColumnType("datetime2");

                b.Property<string>("Email")
                    .IsRequired()
                    .HasColumnType("nvarchar(450)");

                b.Property<string>("Login")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<byte[]>("PasswordHash")
                    .IsRequired()
                    .HasColumnType("varbinary(max)");

                b.Property<byte[]>("PasswordSalt")
                    .IsRequired()
                    .HasColumnType("varbinary(max)");

                b.Property<string>("Role")
                    .IsRequired()
                    .HasColumnType("nvarchar(450)");

                b.Property<DateTime?>("UpdatedAt")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnType("datetime2");

                b.HasKey("Id");

                b.HasIndex("Email")
                    .IsUnique();

                b.HasIndex("Role");

                b.ToTable("Accounts");

                b.UseTpcMappingStrategy();
            });

        modelBuilder.Entity("MessengerX.Domain.Entities.Admins.Admin", b =>
            {
                b.HasBaseType("MessengerX.Domain.Entities.Accounts.Account");

                b.ToTable("Admins");
            });

        modelBuilder.Entity("MessengerX.Domain.Entities.Users.User", b =>
            {
                b.HasBaseType("MessengerX.Domain.Entities.Accounts.Account");

                b.Property<DateTime?>("Birthday")
                    .HasColumnType("datetime2");

                b.Property<string>("Image")
                    .HasColumnType("nvarchar(max)");

                b.ToTable("Users");
            });
#pragma warning restore 612, 618
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Messenger.Persistence.Migrations;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateSequence(name: "AccountSequence");

        migrationBuilder.CreateTable(
            name: "Accounts",
            columns: table =>
                new
                {
                    Id = table.Column<int>(
                        type: "int",
                        nullable: false,
                        defaultValueSql: "NEXT VALUE FOR [AccountSequence]"
                    ),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
            constraints: table =>
            {
                table.PrimaryKey("PK_Accounts", x => x.Id);
            }
        );

        migrationBuilder.CreateTable(
            name: "Admins",
            columns: table =>
                new
                {
                    Id = table.Column<int>(
                        type: "int",
                        nullable: false,
                        defaultValueSql: "NEXT VALUE FOR [AccountSequence]"
                    ),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
            constraints: table =>
            {
                table.PrimaryKey("PK_Admins", x => x.Id);
            }
        );

        migrationBuilder.CreateTable(
            name: "Users",
            columns: table =>
                new
                {
                    Id = table.Column<int>(
                        type: "int",
                        nullable: false,
                        defaultValueSql: "NEXT VALUE FOR [AccountSequence]"
                    ),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
            constraints: table =>
            {
                table.PrimaryKey("PK_Users", x => x.Id);
            }
        );

        migrationBuilder.CreateIndex(
            name: "IX_Accounts_Email",
            table: "Accounts",
            column: "Email",
            unique: true
        );

        migrationBuilder.CreateIndex(name: "IX_Accounts_Role", table: "Accounts", column: "Role");

        migrationBuilder.CreateIndex(
            name: "IX_Admins_Email",
            table: "Admins",
            column: "Email",
            unique: true
        );

        migrationBuilder.CreateIndex(name: "IX_Admins_Role", table: "Admins", column: "Role");

        migrationBuilder.CreateIndex(
            name: "IX_Users_Email",
            table: "Users",
            column: "Email",
            unique: true
        );

        migrationBuilder.CreateIndex(name: "IX_Users_Role", table: "Users", column: "Role");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(name: "Accounts");

        migrationBuilder.DropTable(name: "Admins");

        migrationBuilder.DropTable(name: "Users");

        migrationBuilder.DropSequence(name: "AccountSequence");
    }
}

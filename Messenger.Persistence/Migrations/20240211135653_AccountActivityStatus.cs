using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Messenger.Persistence.Migrations;

/// <inheritdoc />
public partial class AccountActivityStatus : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
            name: "ActivityStatus",
            table: "Users",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "");

        migrationBuilder.AddColumn<string>(
            name: "ActivityStatus",
            table: "Admins",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "");

        migrationBuilder.AddColumn<string>(
            name: "ActivityStatus",
            table: "Accounts",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "ActivityStatus",
            table: "Users");

        migrationBuilder.DropColumn(
            name: "ActivityStatus",
            table: "Admins");

        migrationBuilder.DropColumn(
            name: "ActivityStatus",
            table: "Accounts");
    }
}

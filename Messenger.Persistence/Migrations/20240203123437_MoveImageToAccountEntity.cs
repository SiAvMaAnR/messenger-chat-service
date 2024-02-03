using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Messenger.Persistence.Migrations;

/// <inheritdoc />
public partial class MoveImageToAccountEntity : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
            name: "Image",
            table: "Admins",
            type: "nvarchar(max)",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "Image",
            table: "Accounts",
            type: "nvarchar(max)",
            nullable: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "Image",
            table: "Admins");

        migrationBuilder.DropColumn(
            name: "Image",
            table: "Accounts");
    }
}

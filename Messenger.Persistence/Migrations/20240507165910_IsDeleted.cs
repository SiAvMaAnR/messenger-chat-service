using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Messenger.Persistence.Migrations;

/// <inheritdoc />
public partial class IsDeleted : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.RenameColumn(
            name: "IsDelete",
            table: "Messages",
            newName: "IsDeleted");

        migrationBuilder.AddColumn<bool>(
            name: "IsDeleted",
            table: "Channels",
            type: "bit",
            nullable: false,
            defaultValue: false);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "IsDeleted",
            table: "Channels");

        migrationBuilder.RenameColumn(
            name: "IsDeleted",
            table: "Messages",
            newName: "IsDelete");
    }
}

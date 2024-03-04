using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Messenger.Persistence.Migrations;

/// <inheritdoc />
public partial class CreateInitial : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Accounts",
            columns: table =>
                new
                {
                    Id = table
                        .Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivityStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Discriminator = table.Column<string>(
                        type: "nvarchar(8)",
                        maxLength: 8,
                        nullable: false
                    ),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: true),
                    IsBanned = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
            constraints: table =>
            {
                table.PrimaryKey("PK_Accounts", x => x.Id);
            }
        );

        migrationBuilder.CreateTable(
            name: "Channels",
            columns: table =>
                new
                {
                    Id = table
                        .Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastActivity = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
            constraints: table =>
            {
                table.PrimaryKey("PK_Channels", x => x.Id);
            }
        );

        migrationBuilder.CreateTable(
            name: "RefreshTokens",
            columns: table =>
                new
                {
                    Id = table
                        .Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
            constraints: table =>
            {
                table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                table.ForeignKey(
                    name: "FK_RefreshTokens_Accounts_AccountId",
                    column: x => x.AccountId,
                    principalTable: "Accounts",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade
                );
            }
        );

        migrationBuilder.CreateTable(
            name: "AccountChannel",
            columns: table =>
                new
                {
                    AccountsId = table.Column<int>(type: "int", nullable: false),
                    ChannelsId = table.Column<int>(type: "int", nullable: false)
                },
            constraints: table =>
            {
                table.PrimaryKey("PK_AccountChannel", x => new { x.AccountsId, x.ChannelsId });
                table.ForeignKey(
                    name: "FK_AccountChannel_Accounts_AccountsId",
                    column: x => x.AccountsId,
                    principalTable: "Accounts",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade
                );
                table.ForeignKey(
                    name: "FK_AccountChannel_Channels_ChannelsId",
                    column: x => x.ChannelsId,
                    principalTable: "Channels",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade
                );
            }
        );

        migrationBuilder.CreateTable(
            name: "Messages",
            columns: table =>
                new
                {
                    Id = table
                        .Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    TargetMessageId = table.Column<int>(type: "int", nullable: true),
                    ChannelId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
            constraints: table =>
            {
                table.PrimaryKey("PK_Messages", x => x.Id);
                table.ForeignKey(
                    name: "FK_Messages_Accounts_AuthorId",
                    column: x => x.AuthorId,
                    principalTable: "Accounts",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade
                );
                table.ForeignKey(
                    name: "FK_Messages_Channels_ChannelId",
                    column: x => x.ChannelId,
                    principalTable: "Channels",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade
                );
                table.ForeignKey(
                    name: "FK_Messages_Messages_TargetMessageId",
                    column: x => x.TargetMessageId,
                    principalTable: "Messages",
                    principalColumn: "Id"
                );
            }
        );

        migrationBuilder.CreateTable(
            name: "AccountMessage",
            columns: table =>
                new
                {
                    ReadAccountsId = table.Column<int>(type: "int", nullable: false),
                    ReadMessagesId = table.Column<int>(type: "int", nullable: false)
                },
            constraints: table =>
            {
                table.PrimaryKey(
                    "PK_AccountMessage",
                    x => new { x.ReadAccountsId, x.ReadMessagesId }
                );
                table.ForeignKey(
                    name: "FK_AccountMessage_Accounts_ReadAccountsId",
                    column: x => x.ReadAccountsId,
                    principalTable: "Accounts",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict
                );
                table.ForeignKey(
                    name: "FK_AccountMessage_Messages_ReadMessagesId",
                    column: x => x.ReadMessagesId,
                    principalTable: "Messages",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade
                );
            }
        );

        migrationBuilder.CreateIndex(
            name: "IX_AccountChannel_ChannelsId",
            table: "AccountChannel",
            column: "ChannelsId"
        );

        migrationBuilder.CreateIndex(
            name: "IX_AccountMessage_ReadMessagesId",
            table: "AccountMessage",
            column: "ReadMessagesId"
        );

        migrationBuilder.CreateIndex(
            name: "IX_Accounts_Email",
            table: "Accounts",
            column: "Email",
            unique: true
        );

        migrationBuilder.CreateIndex(name: "IX_Accounts_Role", table: "Accounts", column: "Role");

        migrationBuilder.CreateIndex(
            name: "IX_Messages_AuthorId",
            table: "Messages",
            column: "AuthorId"
        );

        migrationBuilder.CreateIndex(
            name: "IX_Messages_ChannelId",
            table: "Messages",
            column: "ChannelId"
        );

        migrationBuilder.CreateIndex(
            name: "IX_Messages_TargetMessageId",
            table: "Messages",
            column: "TargetMessageId"
        );

        migrationBuilder.CreateIndex(
            name: "IX_RefreshTokens_AccountId",
            table: "RefreshTokens",
            column: "AccountId"
        );
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(name: "AccountChannel");

        migrationBuilder.DropTable(name: "AccountMessage");

        migrationBuilder.DropTable(name: "RefreshTokens");

        migrationBuilder.DropTable(name: "Messages");

        migrationBuilder.DropTable(name: "Accounts");

        migrationBuilder.DropTable(name: "Channels");
    }
}

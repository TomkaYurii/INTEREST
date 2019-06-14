using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace INTEREST.DAL.Migrations
{
    public partial class M_03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6b4f65a-66d4-497c-b652-94c069a01b9b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec35057d-d85e-4199-a078-eb802be6ae0a");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Events",
                newName: "EventText");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Events",
                newName: "EventTime");

            migrationBuilder.AddColumn<bool>(
                name: "Online",
                table: "UserProfiles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeLogin",
                table: "UserProfiles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EventName",
                table: "Events",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StatusMessage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StatusMessageText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusMessage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InternalId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    EventId = table.Column<int>(nullable: false),
                    MessageText = table.Column<string>(nullable: true),
                    StatusMessageId = table.Column<int>(nullable: false),
                    MessageTime = table.Column<DateTime>(nullable: false),
                    UserProfileId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_StatusMessage_StatusMessageId",
                        column: x => x.StatusMessageId,
                        principalTable: "StatusMessage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6f58eb4a-9299-47bc-8ca3-dc7aed78217a", "e8166c5a-2c82-4dc9-986b-c53778ed7765", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bf189f5f-3d14-49de-8d8b-5fb42b75b21f", "d4d8d4af-cf1c-410b-84a9-82dc7ecfed7e", "User", "USER" });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_EventId",
                table: "Messages",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_StatusMessageId",
                table: "Messages",
                column: "StatusMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserProfileId",
                table: "Messages",
                column: "UserProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "StatusMessage");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f58eb4a-9299-47bc-8ca3-dc7aed78217a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf189f5f-3d14-49de-8d8b-5fb42b75b21f");

            migrationBuilder.DropColumn(
                name: "Online",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "TimeLogin",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "EventName",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "EventTime",
                table: "Events",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "EventText",
                table: "Events",
                newName: "Description");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d6b4f65a-66d4-497c-b652-94c069a01b9b", "f44afc61-414c-43b4-99f0-fd8ba9d2b968", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ec35057d-d85e-4199-a078-eb802be6ae0a", "3aa860f7-33cd-40ba-b332-37c1c29f3079", "User", "USER" });
        }
    }
}

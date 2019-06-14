using Microsoft.EntityFrameworkCore.Migrations;

namespace INTEREST.DAL.Migrations
{
    public partial class M_04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_StatusMessage_StatusMessageId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatusMessage",
                table: "StatusMessage");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f58eb4a-9299-47bc-8ca3-dc7aed78217a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf189f5f-3d14-49de-8d8b-5fb42b75b21f");

            migrationBuilder.RenameTable(
                name: "StatusMessage",
                newName: "StatusMessages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatusMessages",
                table: "StatusMessages",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e0b21b6c-f91a-42df-9624-d510de1e6883", "88ad55be-6081-4e5f-9441-db8bb030d43f", "Admin", "ADMIN" },
                    { "962c5b98-45f2-4feb-bc57-5ea4494ac795", "374b2bcd-debf-4139-ac44-e67ab2d3b737", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "StatusMessages",
                columns: new[] { "Id", "StatusMessageText" },
                values: new object[,]
                {
                    { 1, "Message is created" },
                    { 2, "Message is edited" },
                    { 3, "Message is deleted" },
                    { 4, "Message is deleted by admin" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_StatusMessages_StatusMessageId",
                table: "Messages",
                column: "StatusMessageId",
                principalTable: "StatusMessages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_StatusMessages_StatusMessageId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatusMessages",
                table: "StatusMessages");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "962c5b98-45f2-4feb-bc57-5ea4494ac795");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0b21b6c-f91a-42df-9624-d510de1e6883");

            migrationBuilder.DeleteData(
                table: "StatusMessages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StatusMessages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StatusMessages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StatusMessages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.RenameTable(
                name: "StatusMessages",
                newName: "StatusMessage");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatusMessage",
                table: "StatusMessage",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6f58eb4a-9299-47bc-8ca3-dc7aed78217a", "e8166c5a-2c82-4dc9-986b-c53778ed7765", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bf189f5f-3d14-49de-8d8b-5fb42b75b21f", "d4d8d4af-cf1c-410b-84a9-82dc7ecfed7e", "User", "USER" });

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_StatusMessage_StatusMessageId",
                table: "Messages",
                column: "StatusMessageId",
                principalTable: "StatusMessage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

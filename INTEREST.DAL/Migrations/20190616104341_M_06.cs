using Microsoft.EntityFrameworkCore.Migrations;

namespace INTEREST.DAL.Migrations
{
    public partial class M_06 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a69b5eaa-7deb-4c4d-bcf0-302e04da575f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff4a9ee3-df66-4a6c-8a57-609193b74f02");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "UserProfiles",
                newName: "Country");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "UserProfiles",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b752cbed-795b-43b7-81be-a5725821c200", "7eafdc2e-bcc5-4584-887a-7a2dfdbd43d7", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "03f87cd9-c00e-498f-afd4-3dfef0adef52", "85f7c8dd-7d67-4cd1-b5ae-2fb2785bd134", "User", "USER" });

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_CityId",
                table: "UserProfiles",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_Cities_CityId",
                table: "UserProfiles",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_Cities_CityId",
                table: "UserProfiles");

            migrationBuilder.DropIndex(
                name: "IX_UserProfiles_CityId",
                table: "UserProfiles");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f87cd9-c00e-498f-afd4-3dfef0adef52");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b752cbed-795b-43b7-81be-a5725821c200");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "UserProfiles");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "UserProfiles",
                newName: "Location");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ff4a9ee3-df66-4a6c-8a57-609193b74f02", "dd5142d0-5493-47cb-9e78-303d26d9bd85", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a69b5eaa-7deb-4c4d-bcf0-302e04da575f", "424b85b1-855c-463e-bba7-7210b373c47b", "User", "USER" });
        }
    }
}

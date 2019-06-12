using Microsoft.EntityFrameworkCore.Migrations;

namespace INTEREST.DAL.Migrations
{
    public partial class M_02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ae9995b-68c9-434f-b2f5-290396b0ca5e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb467753-b195-48c6-801b-8432af36e0a2");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "UserProfiles",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d6b4f65a-66d4-497c-b652-94c069a01b9b", "f44afc61-414c-43b4-99f0-fd8ba9d2b968", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ec35057d-d85e-4199-a078-eb802be6ae0a", "3aa860f7-33cd-40ba-b332-37c1c29f3079", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6b4f65a-66d4-497c-b652-94c069a01b9b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec35057d-d85e-4199-a078-eb802be6ae0a");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "UserProfiles",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cb467753-b195-48c6-801b-8432af36e0a2", "27a0780d-4e6f-41c0-9282-fa9658574bcd", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8ae9995b-68c9-434f-b2f5-290396b0ca5e", "12c4fbf3-a8e0-479b-aa2a-4a374024af3b", "User", "USER" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace INTEREST.DAL.Migrations
{
    public partial class x_03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20958e93-c900-4445-b7e7-824d3bd670c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6c56eec-daa0-492d-9294-fad2725e84d0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6f272793-ebb0-4770-a0cf-238716f14c9c", "19add03f-2242-414a-a945-d1d4a2f33cd4", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "88b5f792-bc28-4185-8ff8-f795fef01f86", "72bec1d8-2085-4774-8111-415e397eb1af", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f272793-ebb0-4770-a0cf-238716f14c9c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88b5f792-bc28-4185-8ff8-f795fef01f86");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b6c56eec-daa0-492d-9294-fad2725e84d0", "3444c2d3-6f70-4d94-aa5f-9ede6656ce64", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "20958e93-c900-4445-b7e7-824d3bd670c4", "3758b706-eb66-4ffb-80b7-9d36b7fd1255", "User", "USER" });
        }
    }
}

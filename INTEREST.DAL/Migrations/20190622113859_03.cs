using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace INTEREST.DAL.Migrations
{
    public partial class _03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "292abc9a-5acc-40fc-89ef-d8a2c11392f0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc7e7e19-e152-4af3-93d7-08a7f0fa9e80");

            migrationBuilder.RenameColumn(
                name: "EventTime",
                table: "Events",
                newName: "DateTo");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserProfileCategories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateFrom",
                table: "Events",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CategoryEvents",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d42fb894-3ee4-4d16-a4fe-43c091974ded", "c067caee-a5ab-4afe-ab25-e6892eabe85c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ba212885-be4f-477b-b8db-193dfb2176ba", "46999704-7dae-4cfe-9594-e3e61a74b9cc", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba212885-be4f-477b-b8db-193dfb2176ba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d42fb894-3ee4-4d16-a4fe-43c091974ded");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserProfileCategories");

            migrationBuilder.DropColumn(
                name: "DateFrom",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CategoryEvents");

            migrationBuilder.RenameColumn(
                name: "DateTo",
                table: "Events",
                newName: "EventTime");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fc7e7e19-e152-4af3-93d7-08a7f0fa9e80", "3cd03030-7623-4cdd-bc9d-45f811d996d1", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "292abc9a-5acc-40fc-89ef-d8a2c11392f0", "ff22ee04-4a5b-4d32-9aec-a594c35e24a7", "User", "USER" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace INTEREST.DAL.Migrations
{
    public partial class _01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_Locations_LocationId",
                table: "UserProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_Photos_PhotoId",
                table: "UserProfiles");

            migrationBuilder.DropIndex(
                name: "IX_UserProfiles_LocationId",
                table: "UserProfiles");

            migrationBuilder.DropIndex(
                name: "IX_UserProfiles_PhotoId",
                table: "UserProfiles");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e73100c1-e07f-4083-9474-e6e4f8bbec17");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0708ad4-12fe-49d8-9f81-d1feea984123");

            migrationBuilder.AlterColumn<int>(
                name: "PhotoId",
                table: "UserProfiles",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "UserProfiles",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "88d5afe8-3b72-4869-b682-9b430237a051", "ce5dc0ef-3a26-4337-abe7-24a78c028998", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3ad07763-bfa2-428f-97af-0c848eb722b4", "1bc1eb75-847c-41f2-ab8d-f904c13b1d1e", "User", "USER" });

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_LocationId",
                table: "UserProfiles",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_PhotoId",
                table: "UserProfiles",
                column: "PhotoId",
                unique: true,
                filter: "[PhotoId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_Locations_LocationId",
                table: "UserProfiles",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_Photos_PhotoId",
                table: "UserProfiles",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_Locations_LocationId",
                table: "UserProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_Photos_PhotoId",
                table: "UserProfiles");

            migrationBuilder.DropIndex(
                name: "IX_UserProfiles_LocationId",
                table: "UserProfiles");

            migrationBuilder.DropIndex(
                name: "IX_UserProfiles_PhotoId",
                table: "UserProfiles");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ad07763-bfa2-428f-97af-0c848eb722b4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88d5afe8-3b72-4869-b682-9b430237a051");

            migrationBuilder.AlterColumn<int>(
                name: "PhotoId",
                table: "UserProfiles",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "UserProfiles",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f0708ad4-12fe-49d8-9f81-d1feea984123", "a348e47b-2294-4924-9a9e-c0cfd024b94b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e73100c1-e07f-4083-9474-e6e4f8bbec17", "308d176e-361a-4353-8da6-f28302ce629b", "User", "USER" });

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_LocationId",
                table: "UserProfiles",
                column: "LocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_PhotoId",
                table: "UserProfiles",
                column: "PhotoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_Locations_LocationId",
                table: "UserProfiles",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_Photos_PhotoId",
                table: "UserProfiles",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace INTEREST.DAL.Migrations
{
    public partial class _02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryEvent_Categories_CategoryId",
                table: "CategoryEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryEvent_Events_EventId",
                table: "CategoryEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfileCategory_Categories_CategoryId",
                table: "UserProfileCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfileCategory_UserProfiles_UserProfileId",
                table: "UserProfileCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProfileCategory",
                table: "UserProfileCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryEvent",
                table: "CategoryEvent");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ad07763-bfa2-428f-97af-0c848eb722b4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88d5afe8-3b72-4869-b682-9b430237a051");

            migrationBuilder.RenameTable(
                name: "UserProfileCategory",
                newName: "UserProfileCategories");

            migrationBuilder.RenameTable(
                name: "CategoryEvent",
                newName: "CategoryEvents");

            migrationBuilder.RenameIndex(
                name: "IX_UserProfileCategory_CategoryId",
                table: "UserProfileCategories",
                newName: "IX_UserProfileCategories_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryEvent_EventId",
                table: "CategoryEvents",
                newName: "IX_CategoryEvents_EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProfileCategories",
                table: "UserProfileCategories",
                columns: new[] { "UserProfileId", "CategoryId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryEvents",
                table: "CategoryEvents",
                columns: new[] { "CategoryId", "EventId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fc7e7e19-e152-4af3-93d7-08a7f0fa9e80", "3cd03030-7623-4cdd-bc9d-45f811d996d1", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "292abc9a-5acc-40fc-89ef-d8a2c11392f0", "ff22ee04-4a5b-4d32-9aec-a594c35e24a7", "User", "USER" });

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryEvents_Categories_CategoryId",
                table: "CategoryEvents",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryEvents_Events_EventId",
                table: "CategoryEvents",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfileCategories_Categories_CategoryId",
                table: "UserProfileCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfileCategories_UserProfiles_UserProfileId",
                table: "UserProfileCategories",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryEvents_Categories_CategoryId",
                table: "CategoryEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryEvents_Events_EventId",
                table: "CategoryEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfileCategories_Categories_CategoryId",
                table: "UserProfileCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfileCategories_UserProfiles_UserProfileId",
                table: "UserProfileCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProfileCategories",
                table: "UserProfileCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryEvents",
                table: "CategoryEvents");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "292abc9a-5acc-40fc-89ef-d8a2c11392f0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc7e7e19-e152-4af3-93d7-08a7f0fa9e80");

            migrationBuilder.RenameTable(
                name: "UserProfileCategories",
                newName: "UserProfileCategory");

            migrationBuilder.RenameTable(
                name: "CategoryEvents",
                newName: "CategoryEvent");

            migrationBuilder.RenameIndex(
                name: "IX_UserProfileCategories_CategoryId",
                table: "UserProfileCategory",
                newName: "IX_UserProfileCategory_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryEvents_EventId",
                table: "CategoryEvent",
                newName: "IX_CategoryEvent_EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProfileCategory",
                table: "UserProfileCategory",
                columns: new[] { "UserProfileId", "CategoryId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryEvent",
                table: "CategoryEvent",
                columns: new[] { "CategoryId", "EventId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "88d5afe8-3b72-4869-b682-9b430237a051", "ce5dc0ef-3a26-4337-abe7-24a78c028998", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3ad07763-bfa2-428f-97af-0c848eb722b4", "1bc1eb75-847c-41f2-ab8d-f904c13b1d1e", "User", "USER" });

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryEvent_Categories_CategoryId",
                table: "CategoryEvent",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryEvent_Events_EventId",
                table: "CategoryEvent",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfileCategory_Categories_CategoryId",
                table: "UserProfileCategory",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfileCategory_UserProfiles_UserProfileId",
                table: "UserProfileCategory",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GTBack.Repository.Migrations
{
    public partial class thirdweek3change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExtensionUrls_Place_placeId",
                table: "ExtensionUrls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExtensionUrls",
                table: "ExtensionUrls");

            migrationBuilder.RenameTable(
                name: "ExtensionUrls",
                newName: "ExtensionStrings");

            migrationBuilder.RenameIndex(
                name: "IX_ExtensionUrls_placeId",
                table: "ExtensionStrings",
                newName: "IX_ExtensionStrings_placeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExtensionStrings",
                table: "ExtensionStrings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExtensionStrings_Place_placeId",
                table: "ExtensionStrings",
                column: "placeId",
                principalTable: "Place",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExtensionStrings_Place_placeId",
                table: "ExtensionStrings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExtensionStrings",
                table: "ExtensionStrings");

            migrationBuilder.RenameTable(
                name: "ExtensionStrings",
                newName: "ExtensionUrls");

            migrationBuilder.RenameIndex(
                name: "IX_ExtensionStrings_placeId",
                table: "ExtensionUrls",
                newName: "IX_ExtensionUrls_placeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExtensionUrls",
                table: "ExtensionUrls",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExtensionUrls_Place_placeId",
                table: "ExtensionUrls",
                column: "placeId",
                principalTable: "Place",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GTBack.Repository.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "placeid",
                table: "ProfilImages",
                newName: "placeId");

            migrationBuilder.RenameColumn(
                name: "placeid",
                table: "CoverImages",
                newName: "placeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "placeId",
                table: "ProfilImages",
                newName: "placeid");

            migrationBuilder.RenameColumn(
                name: "placeId",
                table: "CoverImages",
                newName: "placeid");
        }
    }
}

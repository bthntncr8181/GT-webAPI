using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GTBack.Repository.Migrations
{
    public partial class il2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "state",
                table: "Customers",
                newName: "ilce");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Customers",
                newName: "il");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ilce",
                table: "Customers",
                newName: "state");

            migrationBuilder.RenameColumn(
                name: "il",
                table: "Customers",
                newName: "city");

     
        }
    }
}

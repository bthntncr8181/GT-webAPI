using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GTBack.Repository.Migrations
{
    public partial class secondweek3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "cusutomerId",
                table: "Place",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Attributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    placeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isExist = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attributes_Place_placeId",
                        column: x => x.placeId,
                        principalTable: "Place",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_placeId",
                table: "Attributes",
                column: "placeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attributes");

            migrationBuilder.DropColumn(
                name: "cusutomerId",
                table: "Place");
        }
    }
}

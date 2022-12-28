using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GTBack.Repository.Migrations
{
    public partial class string2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlaceInWidget",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    placeId = table.Column<long>(type: "bigint", nullable: false),
                    widgetId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceInWidget", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaceInWidget_Place_placeId",
                        column: x => x.placeId,
                        principalTable: "Place",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaceInWidget_Widget_widgetId",
                        column: x => x.widgetId,
                        principalTable: "Widget",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlaceInWidget_placeId",
                table: "PlaceInWidget",
                column: "placeId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceInWidget_widgetId",
                table: "PlaceInWidget",
                column: "widgetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlaceInWidget");
        }
    }
}

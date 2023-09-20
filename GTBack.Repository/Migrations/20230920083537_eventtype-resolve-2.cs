using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GTBack.Repository.Migrations
{
    public partial class eventtyperesolve2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventTypeCompanyRelations_Events_EventId",
                table: "EventTypeCompanyRelations");

            migrationBuilder.DropIndex(
                name: "IX_EventTypeCompanyRelations_EventId",
                table: "EventTypeCompanyRelations");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "EventTypeCompanyRelations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "EventTypeCompanyRelations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EventTypeCompanyRelations_EventId",
                table: "EventTypeCompanyRelations",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventTypeCompanyRelations_Events_EventId",
                table: "EventTypeCompanyRelations",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

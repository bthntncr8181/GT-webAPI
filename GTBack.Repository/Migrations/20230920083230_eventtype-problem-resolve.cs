using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GTBack.Repository.Migrations
{
    public partial class eventtypeproblemresolve : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventTypeCompanyRelations_EventTypes_EventTypeId",
                table: "EventTypeCompanyRelations");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Mail",
                table: "Events");

            migrationBuilder.AlterColumn<int>(
                name: "EventTypeId",
                table: "EventTypeCompanyRelations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EventTypeCompanyRelations_EventTypes_EventTypeId",
                table: "EventTypeCompanyRelations",
                column: "EventTypeId",
                principalTable: "EventTypes",
                principalColumn: "Id"
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventTypeCompanyRelations_EventTypes_EventTypeId",
                table: "EventTypeCompanyRelations");

            migrationBuilder.AlterColumn<int>(
                name: "EventTypeId",
                table: "EventTypeCompanyRelations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Events",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Mail",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_EventTypeCompanyRelations_EventTypes_EventTypeId",
                table: "EventTypeCompanyRelations",
                column: "EventTypeId",
                principalTable: "EventTypes",
                principalColumn: "Id");
        }
    }
}

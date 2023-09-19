using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GTBack.Repository.Migrations
{
    public partial class companyId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventTypeCompanyRelation_Companies_CompanyId",
                table: "EventTypeCompanyRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_EventTypeCompanyRelation_Events_EventId",
                table: "EventTypeCompanyRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_EventTypeCompanyRelation_EventTypes_EventTypeId",
                table: "EventTypeCompanyRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecialAttributeRelation_Users_AdminUserId",
                table: "SpecialAttributeRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecialAttributeRelation_Users_ClientUserId",
                table: "SpecialAttributeRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Companies_CompanyId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpecialAttributeRelation",
                table: "SpecialAttributeRelation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventTypeCompanyRelation",
                table: "EventTypeCompanyRelation");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Events");

            migrationBuilder.RenameTable(
                name: "SpecialAttributeRelation",
                newName: "SpecialAttributeRelations");

            migrationBuilder.RenameTable(
                name: "EventTypeCompanyRelation",
                newName: "EventTypeCompanyRelations");

            migrationBuilder.RenameIndex(
                name: "IX_SpecialAttributeRelation_ClientUserId",
                table: "SpecialAttributeRelations",
                newName: "IX_SpecialAttributeRelations_ClientUserId");

            migrationBuilder.RenameIndex(
                name: "IX_EventTypeCompanyRelation_EventTypeId",
                table: "EventTypeCompanyRelations",
                newName: "IX_EventTypeCompanyRelations_EventTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_EventTypeCompanyRelation_EventId",
                table: "EventTypeCompanyRelations",
                newName: "IX_EventTypeCompanyRelations_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_EventTypeCompanyRelation_CompanyId",
                table: "EventTypeCompanyRelations",
                newName: "IX_EventTypeCompanyRelations_CompanyId");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "EventTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpecialAttributeRelations",
                table: "SpecialAttributeRelations",
                columns: new[] { "AdminUserId", "ClientUserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventTypeCompanyRelations",
                table: "EventTypeCompanyRelations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventTypeCompanyRelations_Companies_CompanyId",
                table: "EventTypeCompanyRelations",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventTypeCompanyRelations_Events_EventId",
                table: "EventTypeCompanyRelations",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventTypeCompanyRelations_EventTypes_EventTypeId",
                table: "EventTypeCompanyRelations",
                column: "EventTypeId",
                principalTable: "EventTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialAttributeRelations_Users_AdminUserId",
                table: "SpecialAttributeRelations",
                column: "AdminUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialAttributeRelations_Users_ClientUserId",
                table: "SpecialAttributeRelations",
                column: "ClientUserId",
                principalTable: "Users",
                principalColumn: "Id"
                );

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Companies_CompanyId",
                table: "Users",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventTypeCompanyRelations_Companies_CompanyId",
                table: "EventTypeCompanyRelations");

            migrationBuilder.DropForeignKey(
                name: "FK_EventTypeCompanyRelations_Events_EventId",
                table: "EventTypeCompanyRelations");

            migrationBuilder.DropForeignKey(
                name: "FK_EventTypeCompanyRelations_EventTypes_EventTypeId",
                table: "EventTypeCompanyRelations");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecialAttributeRelations_Users_AdminUserId",
                table: "SpecialAttributeRelations");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecialAttributeRelations_Users_ClientUserId",
                table: "SpecialAttributeRelations");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Companies_CompanyId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpecialAttributeRelations",
                table: "SpecialAttributeRelations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventTypeCompanyRelations",
                table: "EventTypeCompanyRelations");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "EventTypes");

            migrationBuilder.RenameTable(
                name: "SpecialAttributeRelations",
                newName: "SpecialAttributeRelation");

            migrationBuilder.RenameTable(
                name: "EventTypeCompanyRelations",
                newName: "EventTypeCompanyRelation");

            migrationBuilder.RenameIndex(
                name: "IX_SpecialAttributeRelations_ClientUserId",
                table: "SpecialAttributeRelation",
                newName: "IX_SpecialAttributeRelation_ClientUserId");

            migrationBuilder.RenameIndex(
                name: "IX_EventTypeCompanyRelations_EventTypeId",
                table: "EventTypeCompanyRelation",
                newName: "IX_EventTypeCompanyRelation_EventTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_EventTypeCompanyRelations_EventId",
                table: "EventTypeCompanyRelation",
                newName: "IX_EventTypeCompanyRelation_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_EventTypeCompanyRelations_CompanyId",
                table: "EventTypeCompanyRelation",
                newName: "IX_EventTypeCompanyRelation_CompanyId");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpecialAttributeRelation",
                table: "SpecialAttributeRelation",
                columns: new[] { "AdminUserId", "ClientUserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventTypeCompanyRelation",
                table: "EventTypeCompanyRelation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventTypeCompanyRelation_Companies_CompanyId",
                table: "EventTypeCompanyRelation",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventTypeCompanyRelation_Events_EventId",
                table: "EventTypeCompanyRelation",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventTypeCompanyRelation_EventTypes_EventTypeId",
                table: "EventTypeCompanyRelation",
                column: "EventTypeId",
                principalTable: "EventTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialAttributeRelation_Users_AdminUserId",
                table: "SpecialAttributeRelation",
                column: "AdminUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialAttributeRelation_Users_ClientUserId",
                table: "SpecialAttributeRelation",
                column: "ClientUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Companies_CompanyId",
                table: "Users",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GTBack.Repository.Migrations
{
    public partial class Emp_changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Currency_CurrencyId",
                table: "Employee");

            migrationBuilder.AlterColumn<int>(
                name: "Salary",
                table: "Employee",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CurrencyId",
                table: "Employee",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SalaryType",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Currency_CurrencyId",
                table: "Employee",
                column: "CurrencyId",
                principalTable: "Currency",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Currency_CurrencyId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "SalaryType",
                table: "Employee");

            migrationBuilder.AlterColumn<int>(
                name: "Salary",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CurrencyId",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Currency_CurrencyId",
                table: "Employee",
                column: "CurrencyId",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

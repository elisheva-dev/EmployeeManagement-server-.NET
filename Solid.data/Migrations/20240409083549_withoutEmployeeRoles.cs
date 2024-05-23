using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solid.data.Migrations
{
    public partial class withoutEmployeeRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesRoles_Employees_EmployeeId",
                table: "EmployeesRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeesRoles",
                table: "EmployeesRoles");

            migrationBuilder.RenameTable(
                name: "EmployeesRoles",
                newName: "EmployeeRoles");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeesRoles_EmployeeId",
                table: "EmployeeRoles",
                newName: "IX_EmployeeRoles_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeRoles",
                table: "EmployeeRoles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeRoles_Employees_EmployeeId",
                table: "EmployeeRoles",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeRoles_Employees_EmployeeId",
                table: "EmployeeRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeRoles",
                table: "EmployeeRoles");

            migrationBuilder.RenameTable(
                name: "EmployeeRoles",
                newName: "EmployeesRoles");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeRoles_EmployeeId",
                table: "EmployeesRoles",
                newName: "IX_EmployeesRoles_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeesRoles",
                table: "EmployeesRoles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesRoles_Employees_EmployeeId",
                table: "EmployeesRoles",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}

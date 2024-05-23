using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solid.data.Migrations
{
    public partial class withoutemployeeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesRoles_Employees_EmployeeId",
                table: "EmployeesRoles");

            migrationBuilder.AlterColumn<long>(
                name: "EmployeeId",
                table: "EmployeesRoles",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesRoles_Employees_EmployeeId",
                table: "EmployeesRoles",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesRoles_Employees_EmployeeId",
                table: "EmployeesRoles");

            migrationBuilder.AlterColumn<long>(
                name: "EmployeeId",
                table: "EmployeesRoles",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesRoles_Employees_EmployeeId",
                table: "EmployeesRoles",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

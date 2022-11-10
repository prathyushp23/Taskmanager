using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManager.Migrations
{
    public partial class addedfroring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpTask_Employee_EmployeeEmpId",
                table: "EmpTask");

            migrationBuilder.DropIndex(
                name: "IX_EmpTask_EmployeeEmpId",
                table: "EmpTask");

            migrationBuilder.DropColumn(
                name: "EmployeeEmpId",
                table: "EmpTask");

            migrationBuilder.CreateIndex(
                name: "IX_EmpTask_EmpId",
                table: "EmpTask",
                column: "EmpId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmpTask_Employee_EmpId",
                table: "EmpTask",
                column: "EmpId",
                principalTable: "Employee",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpTask_Employee_EmpId",
                table: "EmpTask");

            migrationBuilder.DropIndex(
                name: "IX_EmpTask_EmpId",
                table: "EmpTask");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeEmpId",
                table: "EmpTask",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EmpTask_EmployeeEmpId",
                table: "EmpTask",
                column: "EmployeeEmpId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmpTask_Employee_EmployeeEmpId",
                table: "EmpTask",
                column: "EmployeeEmpId",
                principalTable: "Employee",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

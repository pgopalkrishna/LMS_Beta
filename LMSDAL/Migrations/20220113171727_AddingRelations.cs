using Microsoft.EntityFrameworkCore.Migrations;

namespace LMSDAL.Migrations
{
    public partial class AddingRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkLocationId",
                table: "WorkLocations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "Organizations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LeaveTypeId",
                table: "LeaveTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LeaveApplicationId",
                table: "LeaveApplications",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LeaveTypeId",
                table: "LeaveApplications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RptManagerId",
                table: "LeaveApplications",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DesignationId",
                table: "Designations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkLocations_OrgnizationId",
                table: "WorkLocations",
                column: "OrgnizationId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkLocations_WorkLocationId",
                table: "WorkLocations",
                column: "WorkLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_OrganizationId",
                table: "Organizations",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveTypes_LeaveTypeId",
                table: "LeaveTypes",
                column: "LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveApplications_LeaveApplicationId",
                table: "LeaveApplications",
                column: "LeaveApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveApplications_RptManagerId",
                table: "LeaveApplications",
                column: "RptManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeId",
                table: "Employees",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Designations_DesignationId",
                table: "Designations",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_Designations_OrgnizationId",
                table: "Designations",
                column: "OrgnizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Designations_Designations_DesignationId",
                table: "Designations",
                column: "DesignationId",
                principalTable: "Designations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Designations_Organizations_OrgnizationId",
                table: "Designations",
                column: "OrgnizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_EmployeeId",
                table: "Employees",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveApplications_Employees_RptManagerId",
                table: "LeaveApplications",
                column: "RptManagerId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveApplications_LeaveApplications_LeaveApplicationId",
                table: "LeaveApplications",
                column: "LeaveApplicationId",
                principalTable: "LeaveApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveTypes_LeaveTypes_LeaveTypeId",
                table: "LeaveTypes",
                column: "LeaveTypeId",
                principalTable: "LeaveTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Organizations_OrganizationId",
                table: "Organizations",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkLocations_Organizations_OrgnizationId",
                table: "WorkLocations",
                column: "OrgnizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkLocations_WorkLocations_WorkLocationId",
                table: "WorkLocations",
                column: "WorkLocationId",
                principalTable: "WorkLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Designations_Designations_DesignationId",
                table: "Designations");

            migrationBuilder.DropForeignKey(
                name: "FK_Designations_Organizations_OrgnizationId",
                table: "Designations");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_EmployeeId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveApplications_Employees_RptManagerId",
                table: "LeaveApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveApplications_LeaveApplications_LeaveApplicationId",
                table: "LeaveApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveTypes_LeaveTypes_LeaveTypeId",
                table: "LeaveTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Organizations_OrganizationId",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkLocations_Organizations_OrgnizationId",
                table: "WorkLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkLocations_WorkLocations_WorkLocationId",
                table: "WorkLocations");

            migrationBuilder.DropIndex(
                name: "IX_WorkLocations_OrgnizationId",
                table: "WorkLocations");

            migrationBuilder.DropIndex(
                name: "IX_WorkLocations_WorkLocationId",
                table: "WorkLocations");

            migrationBuilder.DropIndex(
                name: "IX_Organizations_OrganizationId",
                table: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_LeaveTypes_LeaveTypeId",
                table: "LeaveTypes");

            migrationBuilder.DropIndex(
                name: "IX_LeaveApplications_LeaveApplicationId",
                table: "LeaveApplications");

            migrationBuilder.DropIndex(
                name: "IX_LeaveApplications_RptManagerId",
                table: "LeaveApplications");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployeeId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Designations_DesignationId",
                table: "Designations");

            migrationBuilder.DropIndex(
                name: "IX_Designations_OrgnizationId",
                table: "Designations");

            migrationBuilder.DropColumn(
                name: "WorkLocationId",
                table: "WorkLocations");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "LeaveTypeId",
                table: "LeaveTypes");

            migrationBuilder.DropColumn(
                name: "LeaveApplicationId",
                table: "LeaveApplications");

            migrationBuilder.DropColumn(
                name: "LeaveTypeId",
                table: "LeaveApplications");

            migrationBuilder.DropColumn(
                name: "RptManagerId",
                table: "LeaveApplications");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DesignationId",
                table: "Designations");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace LMSDAL.Migrations
{
    public partial class ChangesInRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveApplications_Employees_RptManagerId",
                table: "LeaveApplications");

            migrationBuilder.DropIndex(
                name: "IX_LeaveApplications_RptManagerId",
                table: "LeaveApplications");

            migrationBuilder.DropColumn(
                name: "RptManagerId",
                table: "LeaveApplications");

            migrationBuilder.AddColumn<int>(
                name: "OrgnanizationId",
                table: "LeaveTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "LeaveRules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LeaveTransactions_OrgnanizationId",
                table: "LeaveTransactions",
                column: "OrgnanizationId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRules_OrganizationId",
                table: "LeaveRules",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveApplications_LeaveTypeId",
                table: "LeaveApplications",
                column: "LeaveTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveApplications_LeaveTypes_LeaveTypeId",
                table: "LeaveApplications",
                column: "LeaveTypeId",
                principalTable: "LeaveTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRules_Organizations_OrganizationId",
                table: "LeaveRules",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveTransactions_Organizations_OrgnanizationId",
                table: "LeaveTransactions",
                column: "OrgnanizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveApplications_LeaveTypes_LeaveTypeId",
                table: "LeaveApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRules_Organizations_OrganizationId",
                table: "LeaveRules");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveTransactions_Organizations_OrgnanizationId",
                table: "LeaveTransactions");

            migrationBuilder.DropIndex(
                name: "IX_LeaveTransactions_OrgnanizationId",
                table: "LeaveTransactions");

            migrationBuilder.DropIndex(
                name: "IX_LeaveRules_OrganizationId",
                table: "LeaveRules");

            migrationBuilder.DropIndex(
                name: "IX_LeaveApplications_LeaveTypeId",
                table: "LeaveApplications");

            migrationBuilder.DropColumn(
                name: "OrgnanizationId",
                table: "LeaveTransactions");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "LeaveRules");

            migrationBuilder.AddColumn<int>(
                name: "RptManagerId",
                table: "LeaveApplications",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LeaveApplications_RptManagerId",
                table: "LeaveApplications",
                column: "RptManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveApplications_Employees_RptManagerId",
                table: "LeaveApplications",
                column: "RptManagerId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

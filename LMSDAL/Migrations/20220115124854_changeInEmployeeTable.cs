using Microsoft.EntityFrameworkCore.Migrations;

namespace LMSDAL.Migrations
{
    public partial class changeInEmployeeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "emergencyContactNo",
                table: "Employees",
                newName: "EmergencyContactNo");

            migrationBuilder.AddColumn<string>(
                name: "EmailId",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "EmergencyContactNo",
                table: "Employees",
                newName: "emergencyContactNo");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace LMSWebApp.Migrations
{
    public partial class seedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3d00856e-d9ae-4626-bad5-3db3248edafe", "0c573190-2da2-4b8e-a60f-def8c5a9f70a", "Admin", "ADMIN" },
                    { "98460f09-79da-4e41-b8ae-cd4248737efb", "c1a05b31-30fd-4b54-8106-d4af0b411f97", "ReportingMgr", "REPORTINGMGR" },
                    { "134c5739-c8cf-45b4-a8e9-328626e4c3f8", "11efdaa1-d014-4373-acda-ba6687bc9d79", "User", "USER" },
                    { "89b2a3c7-eeb6-4d06-9ef7-bfc9e6b3e4ad", "93ba1d0e-89d6-4845-8dfb-7c7146b87498", "SuperAdmin", "SUPERADMIN" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "134c5739-c8cf-45b4-a8e9-328626e4c3f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d00856e-d9ae-4626-bad5-3db3248edafe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89b2a3c7-eeb6-4d06-9ef7-bfc9e6b3e4ad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98460f09-79da-4e41-b8ae-cd4248737efb");
        }
    }
}

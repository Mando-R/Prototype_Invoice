using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesMovie.Migrations
{
    public partial class InitialDB_202112081201 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "ID", "CompanyName", "CreatedOn", "DateOfRegistration", "LatestUpdatedOn", "LocationOfCompany", "TotalPaidinCapital", "UnifiedBusinessNumber" },
                values: new object[] { 1, "RShop", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "CZ Road", 50000m, "12345678" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Company",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}

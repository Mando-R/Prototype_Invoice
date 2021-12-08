using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesMovie.Migrations
{
    public partial class InitialDB_202112081030 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyID",
                table: "ElectronicInvoice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnifiedBusinessNumber = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPaidinCapital = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    LocationOfCompany = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LatestUpdatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ElectronicInvoice_CompanyID",
                table: "ElectronicInvoice",
                column: "CompanyID");

            migrationBuilder.AddForeignKey(
                name: "FK_ElectronicInvoice_Company_CompanyID",
                table: "ElectronicInvoice",
                column: "CompanyID",
                principalTable: "Company",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElectronicInvoice_Company_CompanyID",
                table: "ElectronicInvoice");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropIndex(
                name: "IX_ElectronicInvoice_CompanyID",
                table: "ElectronicInvoice");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                table: "ElectronicInvoice");
        }
    }
}

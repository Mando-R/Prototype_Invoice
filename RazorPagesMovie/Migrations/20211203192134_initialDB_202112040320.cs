using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesMovie.Migrations
{
    public partial class initialDB_202112040320 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "XXX",
                table: "ElectronicInvoice",
                newName: "InvoicePurpose");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InvoicePurpose",
                table: "ElectronicInvoice",
                newName: "XXX");
        }
    }
}

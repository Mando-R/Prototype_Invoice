using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesMovie.Migrations
{
    public partial class initialDB_dev01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExpenseOrRevenue",
                table: "ElectronicInvoice",
                newName: "XXX");

            migrationBuilder.AlterColumn<decimal>(
                name: "InvoiceAmount",
                table: "ElectronicInvoice",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "XXX",
                table: "ElectronicInvoice",
                newName: "ExpenseOrRevenue");

            migrationBuilder.AlterColumn<decimal>(
                name: "InvoiceAmount",
                table: "ElectronicInvoice",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");
        }
    }
}

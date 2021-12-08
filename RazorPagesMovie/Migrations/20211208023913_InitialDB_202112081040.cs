using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesMovie.Migrations
{
    public partial class InitialDB_202112081040 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElectronicInvoice_InvoiceCategory_InvoiceCategoryID",
                table: "ElectronicInvoice");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "ElectronicInvoice");

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceCategoryID",
                table: "ElectronicInvoice",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ElectronicInvoice_InvoiceCategory_InvoiceCategoryID",
                table: "ElectronicInvoice",
                column: "InvoiceCategoryID",
                principalTable: "InvoiceCategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElectronicInvoice_InvoiceCategory_InvoiceCategoryID",
                table: "ElectronicInvoice");

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceCategoryID",
                table: "ElectronicInvoice",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "ElectronicInvoice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ElectronicInvoice_InvoiceCategory_InvoiceCategoryID",
                table: "ElectronicInvoice",
                column: "InvoiceCategoryID",
                principalTable: "InvoiceCategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

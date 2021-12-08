using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesMovie.Migrations
{
    public partial class InitialDB_v202112072346 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceCategoryID",
                table: "ElectronicInvoice",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InvoiceCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceCategory", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "InvoiceCategory",
                columns: new[] { "ID", "Category" },
                values: new object[,]
                {
                    { 1, "Electronic Invoice" },
                    { 2, "Cash Register Uniform Invoice" },
                    { 3, "Duplicate Uniform Invoice" },
                    { 4, "Triplicate Uniform Invoice" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ElectronicInvoice_InvoiceCategoryID",
                table: "ElectronicInvoice",
                column: "InvoiceCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_ElectronicInvoice_InvoiceCategory_InvoiceCategoryID",
                table: "ElectronicInvoice",
                column: "InvoiceCategoryID",
                principalTable: "InvoiceCategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElectronicInvoice_InvoiceCategory_InvoiceCategoryID",
                table: "ElectronicInvoice");

            migrationBuilder.DropTable(
                name: "InvoiceCategory");

            migrationBuilder.DropIndex(
                name: "IX_ElectronicInvoice_InvoiceCategoryID",
                table: "ElectronicInvoice");

            migrationBuilder.DropColumn(
                name: "InvoiceCategoryID",
                table: "ElectronicInvoice");
        }
    }
}

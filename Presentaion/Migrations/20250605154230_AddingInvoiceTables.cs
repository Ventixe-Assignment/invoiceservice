using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Presentaion.Migrations
{
    /// <inheritdoc />
    public partial class AddingInvoiceTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceIssuers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IssuerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssuerAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssuerPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssuerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceIssuers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceIssuers_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceIssuers_InvoiceId",
                table: "InvoiceIssuers",
                column: "InvoiceId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceIssuers");

            migrationBuilder.DropTable(
                name: "Invoices");
        }
    }
}

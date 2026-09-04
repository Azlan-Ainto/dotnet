using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ErpKernmodul.Migrations
{
    /// <inheritdoc />
    public partial class BestellungTabelleHinzugefuegt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bestellungen",
                columns: table => new
                {
                    BestellId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bestelldatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gesamtbetrag = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Lieferadresse = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    kundenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bestellungen", x => x.BestellId);
                    table.ForeignKey(
                        name: "FK_Bestellungen_Kunden_kundenId",
                        column: x => x.kundenId,
                        principalTable: "Kunden",
                        principalColumn: "KundenId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bestellungen_kundenId",
                table: "Bestellungen",
                column: "kundenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bestellungen");
        }
    }
}

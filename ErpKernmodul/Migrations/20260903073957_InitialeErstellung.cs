using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ErpKernmodul.Migrations
{
    /// <inheritdoc />
    public partial class InitialeErstellung : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(name: "Kunden",
                columns: table => new
                {
                    KundenId = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    KundenNummer = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Firmenname = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Ansprechpartner = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Erfassunsdatum = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kunden", x => x.KundenId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable( name: "Kunden");
        }
    }
}

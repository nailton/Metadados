using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Metadados.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ValorOriginal = table.Column<double>(type: "REAL", nullable: false),
                    ValorCorrigido = table.Column<double>(type: "REAL", nullable: false),
                    DataVencimento = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    DataPagamento = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    DiasAtraso = table.Column<int>(type: "INTEGER", nullable: false),
                    Multa = table.Column<int>(type: "INTEGER", nullable: false),
                    Juros = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contas");
        }
    }
}

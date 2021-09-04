using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaVirtual.Infra.Data.Migrations
{
    public partial class datainclusaodataalteracaoproduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Atualizado",
                table: "Produtos",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Incluido",
                table: "Produtos",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Atualizado",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Incluido",
                table: "Produtos");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaVirtual.Infra.Data.Migrations
{
    public partial class CORRECAOENDERECO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Enderecos_EnderecoID",
                table: "Enderecos");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_EnderecoID",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "EnderecoID",
                table: "Enderecos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EnderecoID",
                table: "Enderecos",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_EnderecoID",
                table: "Enderecos",
                column: "EnderecoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Enderecos_EnderecoID",
                table: "Enderecos",
                column: "EnderecoID",
                principalTable: "Enderecos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

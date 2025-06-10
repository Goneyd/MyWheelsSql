using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWheelsSql.Data.Migrations
{
    /// <inheritdoc />
    public partial class ClienteAluquelRela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Compras",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Aluguels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Compras_ClienteId",
                table: "Compras",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Aluguels_ClienteId",
                table: "Aluguels",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aluguels_Clientes_ClienteId",
                table: "Aluguels",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Clientes_ClienteId",
                table: "Compras",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aluguels_Clientes_ClienteId",
                table: "Aluguels");

            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Clientes_ClienteId",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Compras_ClienteId",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Aluguels_ClienteId",
                table: "Aluguels");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Aluguels");
        }
    }
}

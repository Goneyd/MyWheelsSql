using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWheelsSql.Migrations
{
    /// <inheritdoc />
    public partial class AluguelClienteRelacionamneto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Aluguels",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aluguels_Clientes_ClienteId",
                table: "Aluguels");

            migrationBuilder.DropIndex(
                name: "IX_Aluguels_ClienteId",
                table: "Aluguels");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Aluguels");
        }
    }
}

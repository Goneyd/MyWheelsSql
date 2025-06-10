using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWheelsSql.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProdutoCompraRelacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompraId",
                table: "Produto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Produto_CompraId",
                table: "Produto",
                column: "CompraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Compras_CompraId",
                table: "Produto",
                column: "CompraId",
                principalTable: "Compras",
                principalColumn: "CompraId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Compras_CompraId",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Produto_CompraId",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "CompraId",
                table: "Produto");
        }
    }
}

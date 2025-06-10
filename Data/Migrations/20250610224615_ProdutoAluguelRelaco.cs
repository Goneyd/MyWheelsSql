using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWheelsSql.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProdutoAluguelRelaco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AluguelId",
                table: "Produto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Produto_AluguelId",
                table: "Produto",
                column: "AluguelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Aluguels_AluguelId",
                table: "Produto",
                column: "AluguelId",
                principalTable: "Aluguels",
                principalColumn: "AluguelId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Aluguels_AluguelId",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Produto_AluguelId",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "AluguelId",
                table: "Produto");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWheelsSql.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModeloComHeranca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Aluguels_AluguelId",
                table: "Produto");

            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Compras_CompraId",
                table: "Produto");

            migrationBuilder.RenameColumn(
                name: "disponivel",
                table: "Produto",
                newName: "Disponivel");

            migrationBuilder.AlterColumn<int>(
                name: "CompraId",
                table: "Produto",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AluguelId",
                table: "Produto",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Produto",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Marca",
                table: "Produto",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tamanho",
                table: "Produto",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Produto",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoProduto",
                table: "Produto",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Aluguels_AluguelId",
                table: "Produto",
                column: "AluguelId",
                principalTable: "Aluguels",
                principalColumn: "AluguelId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Compras_CompraId",
                table: "Produto",
                column: "CompraId",
                principalTable: "Compras",
                principalColumn: "CompraId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Aluguels_AluguelId",
                table: "Produto");

            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Compras_CompraId",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "Marca",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "Tamanho",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "TipoProduto",
                table: "Produto");

            migrationBuilder.RenameColumn(
                name: "Disponivel",
                table: "Produto",
                newName: "disponivel");

            migrationBuilder.AlterColumn<int>(
                name: "CompraId",
                table: "Produto",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AluguelId",
                table: "Produto",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Aluguels_AluguelId",
                table: "Produto",
                column: "AluguelId",
                principalTable: "Aluguels",
                principalColumn: "AluguelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Compras_CompraId",
                table: "Produto",
                column: "CompraId",
                principalTable: "Compras",
                principalColumn: "CompraId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

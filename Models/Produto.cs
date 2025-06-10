namespace MyWheelsSql.Models;

public class Produto
{
    public int ProdutoId { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public Boolean disponivel { get; set; }
    public int CompraId { get; set; }
    public int AluguelId { get; set; }
}
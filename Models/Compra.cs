namespace MyWheelsSql.Models;

public class Compra
{
    public int CompraId { get; set; }
    public DateTime Data { get; set; }
    public decimal ValorTotal { get; set; }
    public IList<Produto> Produtos { get; set; }
    public int ClienteId { get; set; }

}
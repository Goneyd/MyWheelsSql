namespace MyWheelsSql.Models;

public class Aluguel
{
    public int AluguelId { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public decimal ValorTotal { get; set; }
    public IList<Produto> Items { get; set; }
    public int ClienteId { get; set; }
}
namespace MyWheelsSql.Models;

public class Cliente
{
    public int ClienteId { get; set; }
    public string Cpf { get; set; }
    public string Nome { get; set; }
    public string Endereco { get; set; }
    public IList<Aluguel>? Aluguels { get; set; }
    public IList<Compra>? Compras { get; set; }
    public string Email { get; set; }
}
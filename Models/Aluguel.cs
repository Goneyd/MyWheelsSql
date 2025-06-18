using System.ComponentModel.DataAnnotations;

namespace MyWheelsSql.Models;

public class Aluguel
{
    public int AluguelId { get; set; }
    [Required]
    public DateTime DataInicio { get; set; }
    [Required]
    public DateTime DataFim { get; set; }
    [Required]
    public decimal ValorTotal { get; set; }
    public ICollection<Produto>? Items { get; set; }
    public int ClienteId { get; set; }
    public Cliente? Cliente { get; set; }
}
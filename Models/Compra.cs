using Microsoft.Build.Framework;

namespace MyWheelsSql.Models;

public class Compra
{
    public int CompraId { get; set; }
    
    [Required]
    public DateTime Data { get; set; }
    
    [Required]
    public decimal ValorTotal { get; set; }
    public ICollection<Produto>? Produtos { get; set; }
    public int ClienteId { get; set; }

}
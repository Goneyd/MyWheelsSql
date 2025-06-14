using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace MyWheelsSql.Models;

public class Cliente
{
    public int ClienteId { get; set; }
    
    [Required]
    [StringLength(11)] 
    public string Cpf { get; set; }
    
    [Required]
    public string Nome { get; set; }
    
    [Required]
    public string Endereco { get; set; }
    public IList<Aluguel>? Aluguels { get; set; }
    public IList<Compra>? Compras { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}
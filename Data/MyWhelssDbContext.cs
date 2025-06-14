using Microsoft.EntityFrameworkCore;
using MyWheelsSql.Models;

namespace MyWheelsSql.Data;

public class MyWhelssDbContext : DbContext
{
   public DbSet<Cliente> Clientes { get; set; }
   public DbSet<Compra> Compras { get; set; }
   public DbSet<Aluguel> Aluguels { get; set; } 
   public DbSet<Produto> Produtos { get; set; }
    
    
    protected override void OnConfiguring
    (
        DbContextOptionsBuilder optionsBuilder
        
    )
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        string conn = config.GetConnectionString("MyConn");
        optionsBuilder.UseSqlServer(conn);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Produto>()
            .HasDiscriminator<string>("TipoProduto")
            .HasValue<Bicicleta>("Bicicleta")
            .HasValue<Peca>("Peca");
        
        modelBuilder.Entity<Cliente>()
            .HasIndex(c => c.Cpf)
            .IsUnique();

        modelBuilder.Entity<Cliente>()
            .HasIndex(c => c.Email)
            .IsUnique();

    }

}
using Microsoft.EntityFrameworkCore;
using MyWheelsSql.Models;

namespace MyWheelsSql.Data;

public class MyWhelssDbContext : DbContext
{
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Compra> Compras { get; set; }
    public DbSet<Aluguel> Aluguels { get; set; } 
    public DbSet<Produto> Produto { get; set; }    
    
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

        modelBuilder.Entity<Produto>()
            .HasOne(p => p.Compra)
            .WithMany(c => c.Produtos)
            .HasForeignKey(p => p.CompraId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Produto>()
            .HasOne(p => p.Aluguel)
            .WithMany(a => a.Items)
            .HasForeignKey(p => p.AluguelId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
using Microsoft.EntityFrameworkCore;
using RestApi.Data.Entities;

namespace RestApi.Data;

public class VendasContext : DbContext
{
    public VendasContext(DbContextOptions<VendasContext> options) : base(options) { }

    public DbSet<Produto> Produtos { get; set; }

    public DbSet<Venda> Vendas { get; set; }
    public DbSet<OrdemVenda> OrdensVenda { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurações adicionais podem ser feitas aqui, se necessário

        modelBuilder.Entity<Venda>()
            .HasKey(v => v.Id);

        modelBuilder.Entity<OrdemVenda>()
            .HasKey(o => o.Id);

        // Relacionamento entre OrdemVenda e Produto (opcional)
        modelBuilder.Entity<OrdemVenda>()
            .HasOne(o => o.Produto)
            .WithMany()
            .HasForeignKey(o => o.ProdutoId);
    }
}
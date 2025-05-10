using Domain.Clientes;
using Domain.Commons;
using Domain.Pedidos;
using Domain.Produtos;
using Domain.Usuarios;
using Microsoft.EntityFrameworkCore;

namespace Infra.ApplicationContext;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Cliente> Clientes { get; set; }

    public DbSet<Pedido> Pedidos { get; set; }

    public DbSet<Produto> Produtos { get; set; }

    public DbSet<ItemPedido> ItemPedidos { get; set; }
    
    public DbSet<Usuario> Usuarios { get; set; }
    
    public DbSet<Autenticacao> Autenticacoes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var assembly = typeof(AppDbContext).Assembly;

        modelBuilder.ApplyConfigurationsFromAssembly(assembly);
    }
}
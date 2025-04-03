using Domain.Pedidos;
using Domain.Produtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Configuracoes.ItensPedidos;

public class ItemPedidoConfiguracao : IEntityTypeConfiguration<ItemPedido>
{
    public void Configure(EntityTypeBuilder<ItemPedido> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<Produto>()
            .WithMany()
            .HasForeignKey(x => x.ProdutoId);
        
        builder.HasOne<Pedido>()
            .WithMany()
            .HasForeignKey(x => x.PedidoId);

        builder.Property(x => x.Valor)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(x => x.Quantidade)
            .HasColumnType("decimal(18,2)")
            .IsRequired();
    }
}
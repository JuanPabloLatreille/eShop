using Domain.Produtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Configuracoes.Produtos;

public class ProdutoConfiguracoes : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Nome)
            .HasMaxLength(100)
            .IsRequired();
                
        builder.Property(x => x.Descricao)
            .HasMaxLength(255)
            .IsRequired();
        
        builder.Property(x => x.ValorUnitario)
            .HasColumnType("decimal(18,2)")
            .IsRequired();
        
        builder.Property(x => x.Quantidade)
            .HasColumnType("decimal(18,2 )")
            .IsRequired();
    }
}
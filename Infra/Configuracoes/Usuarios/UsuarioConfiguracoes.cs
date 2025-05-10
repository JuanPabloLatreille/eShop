using Domain.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Configuracoes.Usuarios;

public class UsuarioConfiguracoes : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Nome)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(x => x.Senha)
            .HasMaxLength(255)
            .IsRequired();
        
        builder.Property(x => x.DataCriacao)
            .IsRequired();
    }
}
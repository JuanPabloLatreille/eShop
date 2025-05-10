using Domain.Commons;
using Domain.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Configuracoes.Autenticacoes;

public class AutenticacaoConfiguracao : IEntityTypeConfiguration<Autenticacao>
{
    public void Configure(EntityTypeBuilder<Autenticacao> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Token)
            .HasMaxLength(255)
            .IsRequired();

        builder.HasOne<Usuario>()
            .WithOne()
            .HasForeignKey<Autenticacao>(x => x.UsuarioId);
    }
}
using Domain.Commons;

namespace Domain.Usuarios;

public sealed class Usuario
{
    public Usuario(Guid id, string nome, string senha, DateTime dataCriacao)
    {
        Id = id;
        Nome = nome;
        Senha = senha;
        DataCriacao = dataCriacao;
    }

    public Guid Id { get; private set; }

    public string Nome { get; private set; }

    public string Senha { get; private set; }
    
    public DateTime DataCriacao { get; private set; }

    public static Result<Usuario> Create(string nome, string senha)
    {
        if (string.IsNullOrEmpty(nome))
        {
            return Result<Usuario>.Fail("Nome é obrigatório.");
        }

        if (string.IsNullOrEmpty(senha))
        {
            return Result<Usuario>.Fail("Senha é obrigatório.");
        }
        
        var senhaHash = BCrypt.Net.BCrypt.HashPassword(senha, workFactor: 12);

        return Result<Usuario>.Created(new Usuario(Guid.NewGuid(), nome, senhaHash, DateTime.UtcNow - TimeSpan.FromHours(3)));
    }
}
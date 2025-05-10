namespace Domain.Commons;

public sealed class Autenticacao
{
    private Autenticacao(Guid id, Guid usuarioId, string token, DateTime dataCriacao)
    {
        Id = id;
        UsuarioId = usuarioId;
        Token = token;
        DataCriacao = dataCriacao;
    }

    public Guid Id { get; private set; }

    public Guid UsuarioId { get; private set; }

    public string Token { get; private set; }

    public DateTime DataCriacao { get; private set; }

    public static Result<Autenticacao> Criar(Guid id, Guid usuarioId, string token)
    {
        var dataCriacao = DateTime.UtcNow - TimeSpan.FromHours(3);
        
        return Result<Autenticacao>.Created(new Autenticacao(id, usuarioId, token, dataCriacao));
    }
}
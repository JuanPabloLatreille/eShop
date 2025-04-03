namespace Domain.Clientes;

public sealed class Cliente
{
    private Cliente(Guid id, string nome, string email, DateTime dataCriacao)
    {
        Id = id;
        Nome = nome;
        Email = email;
        DataCriacao = dataCriacao;
    }

    public Guid Id { get; private set; }

    public string Nome { get; private set; }

    public string Email { get; private set; }

    public DateTime DataCriacao { get; private set; }

    public static Cliente CriarCliente(string nome, string email)
    {
        return new Cliente(Guid.NewGuid(), nome, email, DateTime.UtcNow);
    }
}
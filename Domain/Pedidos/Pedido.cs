using Domain.Commons;
using Domain.Produtos;

namespace Domain.Pedidos;

public sealed class Pedido
{
    private readonly HashSet<ItemPedido> _itens = [];

    private Pedido(Guid id, Guid clienteId, string nome, bool aberto)
    {
        Id = id;
        ClienteId = clienteId;
        Nome = nome;
        Aberto = aberto;
    }

    public Guid Id { get; private set; }

    public Guid ClienteId { get; private set; }

    public string Nome { get; private set; }

    public bool Aberto { get; private set; }

    public ICollection<ItemPedido> Itens => _itens;

    public static Result<Pedido> CriarPedido(Guid clienteId, string nome)
    {
        if (clienteId == Guid.Empty)
            return Result<Pedido>.BadRequest("O ID do cliente é inválido.");
            
        if (string.IsNullOrWhiteSpace(nome))
            return Result<Pedido>.BadRequest("O nome do pedido é obrigatório.");
            
        var pedido = new Pedido(Guid.NewGuid(), clienteId, nome, true);
        return Result<Pedido>.Created(pedido, "Pedido criado com sucesso.");
    }

    public static Result FecharPedido(Pedido pedido)
    {
        if (!pedido.Aberto)
            return Result.BadRequest("O pedido já está fechado.");
            
        if (pedido._itens.Count is 0)
            return Result.BadRequest("Não é possível fechar um pedido sem produtos.");
        
        pedido.Aberto = false;
        return Result.Ok("Pedido fechado com sucesso.");
    }
}
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

    public static Pedido CriarPedido(Guid clienteId, string nome)
    {
        return new Pedido(Guid.NewGuid(), clienteId, nome, true);
    }

    public void AdicionarItem(Produto item, decimal quantidade, decimal valor)
    {
        var itemPedido = new ItemPedido(Guid.NewGuid(), Id, item.Id, quantidade, valor);

        _itens.Add(itemPedido);
    }

    public void FecharPedido(Guid pedidoId)
    {
        if (_itens.Count is 0)
        {
            throw new Exception("Não é possível fechar um pedido sem produtos.");
        }

        Aberto = false;
    }
}
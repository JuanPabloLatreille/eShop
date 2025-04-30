using Domain.Commons;

namespace Domain.Pedidos;

public sealed class ItemPedido
{
    public ItemPedido(Guid id, Guid pedidoId, Guid produtoId, decimal quantidade, decimal valor)
    {
        Id = id;
        PedidoId = pedidoId;
        ProdutoId = produtoId;
        Quantidade = quantidade;
        Valor = valor;
    }

    public Guid Id { get; private set; }
    
    public Guid PedidoId { get; private set; }
    
    public Guid ProdutoId { get; private set; }
    
    public decimal Quantidade { get; private set; }
    
    public decimal Valor { get; private set; }

    public static Result<ItemPedido> Criar(Guid pedidoId, Guid produtoId, decimal quantidade, decimal valor)
    {
        return Result<ItemPedido>.Ok(new ItemPedido(Guid.NewGuid(), pedidoId, produtoId, quantidade, valor));
    }
}
using Domain.Pedidos;

namespace Application.Interfaces.ItensPedidos;

public interface IItemPedidoRepository
{
    Task<List<ItemPedido>> ObterItensPedidoAsync();

    Task<ItemPedido?> ObterItemPedidoPorIdAsync(Guid id);
    
    Task<List<ItemPedido>> ObterItensPorPedidoIdAsync(Guid pedidoId);

    Task<ItemPedido> AdicionarItemPedidoAsync(ItemPedido itemPedido);

    Task DeletarItemPedidoAsync(ItemPedido itemPedido);
}
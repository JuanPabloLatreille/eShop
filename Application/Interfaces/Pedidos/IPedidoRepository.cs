using Domain.Pedidos;

namespace Application.Interfaces.Pedidos;

public interface IPedidoRepository
{
    Task<List<Pedido>> ObterPedidosAsync();

    Task<Pedido?> ObterPedidoIdAsync(Guid id);

    Task<Pedido> AdicionarPedidoAsync(Pedido pedido);

    Task DeletarPedidoAsync(Pedido pedido);

    Task FecharPedidoAsync(Guid pedidoId);
}
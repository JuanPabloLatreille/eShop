using Application.Interfaces.ItensPedidos;
using Domain.Pedidos;
using MediatR;

namespace Application.ItensPedidos.Queries;

public class ObterItensPedidosQuery : IRequest<List<ItemPedido>>;

public class ObterItensPedidosQueryHandler : IRequestHandler<ObterItensPedidosQuery, List<ItemPedido>>
{
    private readonly IItemPedidoRepository _itemPedidoRepository;

    public ObterItensPedidosQueryHandler(IItemPedidoRepository itemPedidoRepository)
    {
        _itemPedidoRepository = itemPedidoRepository;
    }

    public async Task<List<ItemPedido>> Handle(ObterItensPedidosQuery request, CancellationToken cancellationToken)
    {
        return await _itemPedidoRepository.ObterItensPedidoAsync();
    }
}
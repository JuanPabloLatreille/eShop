using Application.Interfaces.ItensPedidos;
using Domain.Commons;
using Domain.Pedidos;
using MediatR;

namespace Application.ItensPedidos.Queries;

public class ObterItensPedidosQuery : IRequest<Result<List<ItemPedido>>>;

public class ObterItensPedidosQueryHandler : IRequestHandler<ObterItensPedidosQuery, Result<List<ItemPedido>>>
{
    private readonly IItemPedidoRepository _itemPedidoRepository;

    public ObterItensPedidosQueryHandler(IItemPedidoRepository itemPedidoRepository)
    {
        _itemPedidoRepository = itemPedidoRepository;
    }

    public async Task<Result<List<ItemPedido>>> Handle(ObterItensPedidosQuery request,
        CancellationToken cancellationToken)
    {
        return Result<List<ItemPedido>>.Ok(await _itemPedidoRepository.ObterItensPedidoAsync());
    }
}
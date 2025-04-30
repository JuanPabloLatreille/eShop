using Application.Interfaces.ItensPedidos;
using Domain.Commons;
using Domain.Pedidos;
using MediatR;

namespace Application.ItensPedidos.Queries;

public class ObterItemPedidoQuery : IRequest<Result<ItemPedido>>
{
    public Guid Id { get; set; }
}

public class ObterItemPedidoQueryHandler : IRequestHandler<ObterItemPedidoQuery, Result<ItemPedido>>
{
    private readonly IItemPedidoRepository _itemPedidoRepository;

    public ObterItemPedidoQueryHandler(IItemPedidoRepository itemPedidoRepository)
    {
        _itemPedidoRepository = itemPedidoRepository;
    }

    public async Task<Result<ItemPedido>> Handle(ObterItemPedidoQuery request, CancellationToken cancellationToken)
    {
        var itemPedido = await _itemPedidoRepository.ObterItemPedidoPorIdAsync(request.Id);

        if (itemPedido is null)
        {
            return Result<ItemPedido>.NotFound("Item do pedido não encontrado.");
        }

        return Result<ItemPedido>.Ok(itemPedido);
    }
}
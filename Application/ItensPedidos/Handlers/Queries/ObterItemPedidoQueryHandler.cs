using Application.Interfaces.ItensPedidos;
using Application.ItensPedidos.Queries;
using Domain.Pedidos;
using MediatR;

namespace Application.ItensPedidos.Handlers.Queries;

public class ObterItemPedidoQueryHandler : IRequestHandler<ObterItemPedidoQuery, ItemPedido>
{
    private readonly IItemPedidoRepository _itemPedidoRepository;

    public ObterItemPedidoQueryHandler(IItemPedidoRepository itemPedidoRepository)
    {
        _itemPedidoRepository = itemPedidoRepository;
    }

    public async Task<ItemPedido> Handle(ObterItemPedidoQuery request, CancellationToken cancellationToken)
    {
        var itemPedido = await _itemPedidoRepository.ObterItemPedidoPorIdAsync(request.Id);

        if (itemPedido is null)
        {
            throw new Exception("Item do pedido não encontrado.");
        }

        return itemPedido;
    }
}
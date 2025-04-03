using Application.Interfaces.ItensPedidos;
using Application.ItensPedidos.Commands;
using Domain.Pedidos;
using MediatR;

namespace Application.ItensPedidos.Handlers.Commands;

public class AddItemPedidoCommandHandler : IRequestHandler<AddItemPedidoCommand, ItemPedido>
{
    private readonly IItemPedidoRepository _itemPedidoRepository;

    public AddItemPedidoCommandHandler(IItemPedidoRepository itemPedidoRepository)
    {
        _itemPedidoRepository = itemPedidoRepository;
    }

    public async Task<ItemPedido> Handle(AddItemPedidoCommand request, CancellationToken cancellationToken)
    {
        var item = ItemPedido.Criar(request.PedidoId, request.ProdutoId, request.Quantidade, request.Valor);
        await _itemPedidoRepository.AdicionarItemPedidoAsync(item);

        return item;
    }
}
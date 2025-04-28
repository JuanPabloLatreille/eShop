using Application.Interfaces.ItensPedidos;
using Application.Interfaces.Pedidos;
using Domain.Pedidos;
using MediatR;

namespace Application.ItensPedidos.Commands;

public class AddItemPedidoCommand : IRequest<ItemPedido>
{
    public Guid PedidoId { get; set; }
    
    public Guid ProdutoId { get; set; }
    
    public decimal Quantidade { get; set; }
    
    public decimal Valor { get; set; }
}

public class AddItemPedidoCommandHandler : IRequestHandler<AddItemPedidoCommand, ItemPedido>
{
    private readonly IItemPedidoRepository _itemPedidoRepository;
    private readonly IPedidoRepository _pedidoRepository;

    public AddItemPedidoCommandHandler(IItemPedidoRepository itemPedidoRepository, IPedidoRepository pedidoRepository)
    {
        _itemPedidoRepository = itemPedidoRepository;
        _pedidoRepository = pedidoRepository;
    }

    public async Task<ItemPedido> Handle(AddItemPedidoCommand request, CancellationToken cancellationToken)
    {
        var pedido = await _pedidoRepository.ObterPedidoIdAsync(request.PedidoId);

        if (pedido is null)
        {
            throw new Exception("Pedido não encontrado.");
        }

        if (!pedido.Aberto)
        {
            throw new Exception("Não é possível adicionar produtos a um pedido fechado.");
        }

        var item = ItemPedido.Criar(request.PedidoId, request.ProdutoId, request.Quantidade, request.Valor);
        await _itemPedidoRepository.AdicionarItemPedidoAsync(item);

        return item;
    }
}
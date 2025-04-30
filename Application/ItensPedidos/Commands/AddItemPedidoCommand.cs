using Application.Interfaces.ItensPedidos;
using Application.Interfaces.Pedidos;
using Domain.Commons;
using Domain.Pedidos;
using MediatR;

namespace Application.ItensPedidos.Commands;

public class AddItemPedidoCommand : IRequest<Result<ItemPedido>>
{
    public Guid PedidoId { get; set; }

    public Guid ProdutoId { get; set; }

    public decimal Quantidade { get; set; }

    public decimal Valor { get; set; }
}

public class AddItemPedidoCommandHandler : IRequestHandler<AddItemPedidoCommand, Result<ItemPedido>>
{
    private readonly IItemPedidoRepository _itemPedidoRepository;
    private readonly IPedidoRepository _pedidoRepository;

    public AddItemPedidoCommandHandler(IItemPedidoRepository itemPedidoRepository, IPedidoRepository pedidoRepository)
    {
        _itemPedidoRepository = itemPedidoRepository;
        _pedidoRepository = pedidoRepository;
    }

    public async Task<Result<ItemPedido>> Handle(AddItemPedidoCommand request, CancellationToken cancellationToken)
    {
        var pedido = await _pedidoRepository.ObterPedidoIdAsync(request.PedidoId);

        if (pedido is null)
        {
            return Result<ItemPedido>.NotFound("Pedido não encontrado.");
        }

        if (!pedido.Aberto)
        {
            return Result<ItemPedido>.Fail("Não é possível adicionar produtos a um pedido fechado.");
        }

        var itemResult = ItemPedido.Criar(request.PedidoId, request.ProdutoId, request.Quantidade, request.Valor);

        if (!itemResult.Success)
        {
            return itemResult;
        }

        var item = itemResult.Data!;

        await _itemPedidoRepository.AdicionarItemPedidoAsync(item);

        return Result<ItemPedido>.Ok(item);
    }
}
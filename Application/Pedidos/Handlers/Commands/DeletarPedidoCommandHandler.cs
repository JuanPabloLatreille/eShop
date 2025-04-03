using Application.Interfaces.Pedidos;
using Application.Pedidos.Commands;
using MediatR;

namespace Application.Pedidos.Handlers.Commands;

public class DeletarPedidoCommandHandler : IRequestHandler<DeletarPedidoCommand>
{
    private readonly IPedidoRepository _pedidoRepository;

    public DeletarPedidoCommandHandler(IPedidoRepository pedidoRepository)
    {
        _pedidoRepository = pedidoRepository;
    }

    public async Task Handle(DeletarPedidoCommand request, CancellationToken cancellationToken)
    {
        var pedido = await _pedidoRepository.ObterPedidoIdAsync(request.Id);

        if (pedido == null)
        {
            throw new Exception("Pedido não encontrado.");
        }

        await _pedidoRepository.DeletarPedidoAsync(pedido);
    }
}
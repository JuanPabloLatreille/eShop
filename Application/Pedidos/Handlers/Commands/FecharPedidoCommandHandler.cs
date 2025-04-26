using Application.Interfaces.Pedidos;
using Application.Pedidos.Commands;
using Domain.Commons;
using MediatR;

namespace Application.Pedidos.Handlers.Commands;

public class FecharPedidoCommandHandler : IRequestHandler<FecharPedidoCommand, Result>
{
    private readonly IPedidoRepository _pedidoRepository;

    public FecharPedidoCommandHandler(IPedidoRepository pedidoRepository)
    {
        _pedidoRepository = pedidoRepository;
    }

    public async Task<Result> Handle(FecharPedidoCommand request, CancellationToken cancellationToken)
    {
        var pedido = await _pedidoRepository.ObterPedidoIdAsync(request.PedidoId);

        if (pedido is null)
        {
            throw new Exception("Pedido não encontrado.");
        }
        
        await _pedidoRepository.FecharPedidoAsync(pedido);
        
        return Result.Ok();
    }
}
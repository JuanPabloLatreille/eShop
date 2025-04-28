using Application.Interfaces.Pedidos;
using Domain.Commons;
using MediatR;

namespace Application.Pedidos.Commands;

public class FecharPedidoCommand : IRequest<Result>
{
    public Guid PedidoId { get; set; }
}

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
            return Result.NotFound("Pedido não encontrado.");
        }

        await _pedidoRepository.FecharPedidoAsync(pedido);

        return Result.Ok();
    }
}
using Application.Interfaces.Pedidos;
using Domain.Commons;
using MediatR;

namespace Application.Pedidos.Commands;

public class DeletarPedidoCommand : IRequest<Result>
{
    public Guid Id { get; set; }
}

public class DeletarPedidoCommandHandler : IRequestHandler<DeletarPedidoCommand, Result>
{
    private readonly IPedidoRepository _pedidoRepository;

    public DeletarPedidoCommandHandler(IPedidoRepository pedidoRepository)
    {
        _pedidoRepository = pedidoRepository;
    }

    public async Task<Result> Handle(DeletarPedidoCommand request, CancellationToken cancellationToken)
    {
        var pedido = await _pedidoRepository.ObterPedidoIdAsync(request.Id);

        if (pedido == null)
        {
            return Result.NotFound("Pedido não encontrado.");
        }

        await _pedidoRepository.DeletarPedidoAsync(pedido);
        
        return Result.Ok();
    }
}
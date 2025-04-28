using Application.Interfaces.Pedidos;
using Domain.Commons;
using Domain.Pedidos;
using MediatR;

namespace Application.Pedidos.Queries;

public class ObterPedidoQuery : IRequest<Result<Pedido>>
{
    public Guid Id { get; set; }
}

public class ObterPedidoQueryHandler : IRequestHandler<ObterPedidoQuery, Result<Pedido>>
{
    private readonly IPedidoRepository _pedidoRepository;

    public ObterPedidoQueryHandler(IPedidoRepository pedidoRepository)
    {
        _pedidoRepository = pedidoRepository;
    }

    public async Task<Result<Pedido>> Handle(ObterPedidoQuery request, CancellationToken cancellationToken)
    {
        var pedido = await _pedidoRepository.ObterPedidoIdAsync(request.Id);

        if (pedido == null)
        {
            return Result<Pedido>.NotFound("Pedido não encontrado.");
        }

        return Result<Pedido>.Ok(pedido);
    }
}
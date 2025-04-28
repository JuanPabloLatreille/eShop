using Application.Interfaces.Pedidos;
using Domain.Commons;
using Domain.Pedidos;
using MediatR;

namespace Application.Pedidos.Queries;

public class ObterPedidosQuery : IRequest<Result<List<Pedido>>>;

public class ObterPedidosQueryHandler : IRequestHandler<ObterPedidosQuery, Result<List<Pedido>>>
{
    private readonly IPedidoRepository _pedidoRepository;

    public ObterPedidosQueryHandler(IPedidoRepository pedidoRepository)
    {
        _pedidoRepository = pedidoRepository;
    }

    public async Task<Result<List<Pedido>>> Handle(ObterPedidosQuery request, CancellationToken cancellationToken)
    {
        return Result<List<Pedido>>.Ok(await _pedidoRepository.ObterPedidosAsync());
    }
}
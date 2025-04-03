using Application.Interfaces.Pedidos;
using Application.Pedidos.Queries;
using Domain.Pedidos;
using MediatR;

namespace Application.Pedidos.Handlers.Queries;

public class ObterPedidosQueryHandler : IRequestHandler<ObterPedidosQuery, List<Pedido>>
{
    private readonly IPedidoRepository _pedidoRepository;

    public ObterPedidosQueryHandler(IPedidoRepository pedidoRepository)
    {
        _pedidoRepository = pedidoRepository;
    }

    public async Task<List<Pedido>> Handle(ObterPedidosQuery request, CancellationToken cancellationToken)
    {
        return await _pedidoRepository.ObterPedidosAsync();
    }
}
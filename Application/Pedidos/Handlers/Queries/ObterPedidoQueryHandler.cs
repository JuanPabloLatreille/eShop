using Application.Interfaces.Pedidos;
using Application.Pedidos.Queries;
using Domain.Pedidos;
using MediatR;

namespace Application.Pedidos.Handlers.Queries;

public class ObterPedidoQueryHandler : IRequestHandler<ObterPedidoQuery, Pedido>
{
    private readonly IPedidoRepository _pedidoRepository;

    public ObterPedidoQueryHandler(IPedidoRepository pedidoRepository)
    {
        _pedidoRepository = pedidoRepository;
    }

    public async Task<Pedido> Handle(ObterPedidoQuery request, CancellationToken cancellationToken)
    {
        var pedido = await _pedidoRepository.ObterPedidoIdAsync(request.Id);

        if (pedido == null)
        {
            throw new Exception("Pedido não encontrado.");
        }

        return pedido;
    }
}
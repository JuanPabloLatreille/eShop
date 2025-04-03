using Domain.Pedidos;
using MediatR;

namespace Application.Pedidos.Queries;

public class ObterPedidoQuery : IRequest<Pedido>
{
    public Guid Id { get; set; }
}
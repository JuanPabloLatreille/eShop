using Domain.Commons;
using MediatR;

namespace Application.Pedidos.Commands;

public class FecharPedidoCommand : IRequest<Result>
{
    public Guid PedidoId { get; set; }
}
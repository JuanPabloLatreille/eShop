using Domain.Pedidos;
using MediatR;

namespace Application.Pedidos.Commands;

public class CriarPedidoCommand : IRequest<Pedido>
{
    public required Guid ClienteId { get; set; }

    public required string Nome { get; set; }
}
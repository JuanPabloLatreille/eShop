using Domain.Commons;
using Domain.Pedidos;
using MediatR;

namespace Application.Pedidos.Commands;

public class CriarPedidoCommand : IRequest<Result<Pedido>>
{
    public required Guid ClienteId { get; set; }

    public required string Nome { get; set; }
}
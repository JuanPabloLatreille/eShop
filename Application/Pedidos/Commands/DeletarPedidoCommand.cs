using MediatR;

namespace Application.Pedidos.Commands;

public class DeletarPedidoCommand : IRequest
{
    public Guid Id { get; set; }
}
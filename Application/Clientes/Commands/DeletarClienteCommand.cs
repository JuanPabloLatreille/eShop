using MediatR;

namespace Application.Clientes.Commands;

public class DeletarClienteCommand : IRequest
{
    public Guid Id { get; set; }
}
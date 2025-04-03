using Domain.Clientes;
using MediatR;

namespace Application.Clientes.Commands;

public class CriarClienteCommand : IRequest<Cliente>
{
    public required string Nome { get; set; }
    
    public required string Email { get; set; }
}
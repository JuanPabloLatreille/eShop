using Domain.Clientes;
using MediatR;

namespace Application.Clientes.Queries;

public class ObterClienteQuery : IRequest<Cliente>
{
    public Guid Id { get; set; }
}

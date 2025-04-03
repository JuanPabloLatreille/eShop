using Application.Clientes.Queries;
using Application.Interfaces.Clientes;
using Domain.Clientes;
using MediatR;

namespace Application.Clientes.Handlers.Queries;

public class ObterClientesQueryHandler : IRequestHandler<ObterClientesQuery, List<Cliente>>
{
    private readonly IClienteRepository _clienteRepository;

    public ObterClientesQueryHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    async Task<List<Cliente>> IRequestHandler<ObterClientesQuery, List<Cliente>>.Handle(ObterClientesQuery request, CancellationToken cancellationToken)
    {
        return await _clienteRepository.ObterClientesAsync();
    }
}

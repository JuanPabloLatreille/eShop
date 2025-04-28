using Application.Interfaces.Clientes;
using Domain.Clientes;
using Domain.Commons;
using MediatR;

namespace Application.Clientes.Queries;

public class ObterClientesQuery : IRequest<Result<List<Cliente>>>;

public class ObterClientesQueryHandler : IRequestHandler<ObterClientesQuery, Result<List<Cliente>>>
{
    private readonly IClienteRepository _clienteRepository;

    public ObterClientesQueryHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<Result<List<Cliente>>> Handle(ObterClientesQuery request, CancellationToken cancellationToken)
    {
        var clientes = await _clienteRepository.ObterClientesAsync();
        
        return Result<List<Cliente>>.Ok(clientes);
    }
}

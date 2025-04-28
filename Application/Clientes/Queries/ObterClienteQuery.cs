using Application.Interfaces.Clientes;
using Domain.Clientes;
using Domain.Commons;
using MediatR;

namespace Application.Clientes.Queries;

public class ObterClienteQuery : IRequest<Result<Cliente>>
{
    public Guid Id { get; set; }
}

public class ObterClienteQueryHandler : IRequestHandler<ObterClienteQuery, Result<Cliente>>
{
    private readonly IClienteRepository _clienteRepository;

    public ObterClienteQueryHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<Result<Cliente>> Handle(ObterClienteQuery request, CancellationToken cancellationToken)
    {
        var cliente = await _clienteRepository.ObterClienteIdAsync(request.Id);

        if (cliente is null)
        {
            return Result<Cliente>.NotFound("Cliente não encontrado.");
        }

        return Result<Cliente>.Ok(cliente);
    }
}
using Application.Clientes.Queries;
using Application.Interfaces.Clientes;
using Domain.Clientes;
using MediatR;

namespace Application.Clientes.Handlers.Queries;

public class ObterClienteQueryHandler : IRequestHandler<ObterClienteQuery, Cliente>
{
    private readonly IClienteRepository _clienteRepository;

    public ObterClienteQueryHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<Cliente> Handle(ObterClienteQuery request, CancellationToken cancellationToken)
    {
        var cliente = await _clienteRepository.ObterClienteIdAsync(request.Id);

        if (cliente is null)
        {
            throw new Exception("Cliente não encontrado.");
        }

        return cliente;
    }
}

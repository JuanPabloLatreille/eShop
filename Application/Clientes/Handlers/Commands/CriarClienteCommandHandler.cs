using Application.Clientes.Commands;
using Application.Interfaces.Clientes;
using Domain.Clientes;
using MediatR;

namespace Application.Clientes.Handlers.Commands;

public class CriarClienteCommandHandler : IRequestHandler<CriarClienteCommand, Cliente>
{
    private readonly IClienteRepository _clienteRepository;

    public CriarClienteCommandHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<Cliente> Handle(CriarClienteCommand request, CancellationToken cancellationToken)
    {
        var cliente = Cliente.CriarCliente(request.Nome, request.Email);
        await _clienteRepository.AdicionarClienteAsync(cliente);

        return cliente;
    }
}
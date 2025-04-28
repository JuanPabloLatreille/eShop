using Application.Interfaces.Clientes;
using Domain.Clientes;
using Domain.Commons;
using MediatR;

namespace Application.Clientes.Commands;

public class CriarClienteCommand : IRequest<Result<Cliente>>
{
    public required string Nome { get; set; }
    
    public required string Email { get; set; }
}

public class CriarClienteCommandHandler : IRequestHandler<CriarClienteCommand, Result<Cliente>>
{
    private readonly IClienteRepository _clienteRepository;

    public CriarClienteCommandHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<Result<Cliente>> Handle(CriarClienteCommand request, CancellationToken cancellationToken)
    {
        var clienteResult = Cliente.CriarCliente(request.Nome, request.Email);

        if (!clienteResult.Success)
        {
            return clienteResult;
        }

        var cliente = clienteResult.Data!;

        await _clienteRepository.AdicionarClienteAsync(cliente);

        return Result<Cliente>.Created(cliente, "Cliente criado com sucesso.");
    }
}
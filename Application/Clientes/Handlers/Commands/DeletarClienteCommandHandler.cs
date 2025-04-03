using Application.Clientes.Commands;
using Application.Interfaces.Clientes;
using MediatR;

namespace Application.Clientes.Handlers.Commands;

public class DeletarClienteCommandHandler : IRequestHandler<DeletarClienteCommand>
{
    private readonly IClienteRepository _clienteRepository;

    public DeletarClienteCommandHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task Handle(DeletarClienteCommand request, CancellationToken cancellationToken)
    {
        var cliente = await _clienteRepository.ObterClienteIdAsync(request.Id);

        if (cliente is null)
        {
            throw new Exception("Cliente não encontrado.");
        }

        await _clienteRepository.DeletarClienteAsync(cliente);
    }
}

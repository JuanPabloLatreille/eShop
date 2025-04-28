using Application.Interfaces.Clientes;
using Domain.Commons;
using MediatR;

namespace Application.Clientes.Commands;

public class DeletarClienteCommand : IRequest<Result>
{
    public Guid Id { get; set; }
}

public class DeletarClienteCommandHandler : IRequestHandler<DeletarClienteCommand, Result>
{
    private readonly IClienteRepository _clienteRepository;

    public DeletarClienteCommandHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<Result> Handle(DeletarClienteCommand request, CancellationToken cancellationToken)
    {
        var cliente = await _clienteRepository.ObterClienteIdAsync(request.Id);

        if (cliente is null)
        {
            return Result.NotFound("Cliente não encontrado.");
        }

        await _clienteRepository.DeletarClienteAsync(cliente);
        
        return Result.Ok();
    }
}

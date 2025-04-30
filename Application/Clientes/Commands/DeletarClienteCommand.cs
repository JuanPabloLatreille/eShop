using Application.Interfaces.Clientes;
using Application.Interfaces.Pedidos;
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
    private readonly IPedidoRepository _pedidoRepository;

    public DeletarClienteCommandHandler(
        IClienteRepository clienteRepository,
        IPedidoRepository pedidoRepository)
    {
        _clienteRepository = clienteRepository;
        _pedidoRepository = pedidoRepository;
    }

    public async Task<Result> Handle(DeletarClienteCommand request, CancellationToken cancellationToken)
    {
        var cliente = await _clienteRepository.ObterClienteIdAsync(request.Id);

        if (cliente is null)
        {
            return Result.NotFound("Cliente não encontrado.");
        }
        
        var clientePossuiPedidoAberto = await _pedidoRepository.ObterPedidoClienteIdAsync(cliente.Id);

        if (clientePossuiPedidoAberto is not null)
        {
            return Result.Unauthorized("Não é possível deletar o cliente. Pois, possui pedidos em aberto.");
        }

        await _clienteRepository.DeletarClienteAsync(cliente);
        
        return Result.Ok();
    }
}

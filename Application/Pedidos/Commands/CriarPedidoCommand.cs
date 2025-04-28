using Application.Interfaces.Clientes;
using Application.Interfaces.Pedidos;
using Domain.Commons;
using Domain.Pedidos;
using MediatR;

namespace Application.Pedidos.Commands;

public class CriarPedidoCommand : IRequest<Result<Pedido>>
{
    public required Guid ClienteId { get; set; }

    public required string Nome { get; set; }
}

public class CriarPedidoCommandHandler : IRequestHandler<CriarPedidoCommand, Result<Pedido>>
{
    private readonly IPedidoRepository _pedidoRepository;
    private readonly IClienteRepository _clienteRepository;

    public CriarPedidoCommandHandler(IPedidoRepository pedidoRepository, IClienteRepository clienteRepository)
    {
        _pedidoRepository = pedidoRepository;
        _clienteRepository = clienteRepository;
    }

    public async Task<Result<Pedido>> Handle(CriarPedidoCommand request, CancellationToken cancellationToken)
    {
        var cliente = await _clienteRepository.ObterClienteIdAsync(request.ClienteId);

        if (cliente is null)
        {
            return Result<Pedido>.NotFound($"Cliente com ID {request.ClienteId} não encontrado.");
        }
        
        // Criar o pedido usando o factory method que já retorna um Result
        var pedidoResult = Pedido.CriarPedido(request.ClienteId, request.Nome);

        if (!pedidoResult.Success)
        {
            return pedidoResult; // Propaga o resultado de falha do domínio
        }
        
        var pedido = pedidoResult.Data!;
        
        // Persistir o pedido no repositório
        await _pedidoRepository.AdicionarPedidoAsync(pedido);
        
        // Retornar o resultado de sucesso
        return Result<Pedido>.Created(pedido, "Pedido criado com sucesso.");
    }
}
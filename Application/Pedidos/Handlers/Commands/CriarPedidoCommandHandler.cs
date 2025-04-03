using Application.Interfaces.Clientes;
using Application.Interfaces.Pedidos;
using Application.Pedidos.Commands;
using Domain.Pedidos;
using MediatR;

namespace Application.Pedidos.Handlers.Commands;

public class CriarPedidoCommandHandler : IRequestHandler<CriarPedidoCommand, Pedido>
{
    private readonly IPedidoRepository _pedidoRepository;
    private readonly IClienteRepository _clienteRepository;

    public CriarPedidoCommandHandler(IPedidoRepository pedidoRepository, IClienteRepository clienteRepository)
    {
        _pedidoRepository = pedidoRepository;
        _clienteRepository = clienteRepository;
    }

    public async Task<Pedido> Handle(CriarPedidoCommand request, CancellationToken cancellationToken)
    {
        var cliente = await _clienteRepository.ObterClienteIdAsync(request.ClienteId);

        if (cliente is null)
        {
            throw new Exception("Cliente não encontrado.");
        }
        
        var pedido = Pedido.CriarPedido(request.ClienteId, request.Nome);
        await _pedidoRepository.AdicionarPedidoAsync(pedido);

        return pedido;
    }
}
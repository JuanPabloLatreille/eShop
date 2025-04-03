using Domain.Pedidos;
using MediatR;

namespace Application.Pedidos.Queries;

public class ObterPedidosQuery : IRequest<List<Pedido>>
{
    
}
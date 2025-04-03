using Domain.Pedidos;
using MediatR;

namespace Application.ItensPedidos.Queries;

public class ObterItensPedidosQuery : IRequest<List<ItemPedido>>;
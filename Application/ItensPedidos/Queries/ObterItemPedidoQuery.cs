using Domain.Pedidos;
using MediatR;

namespace Application.ItensPedidos.Queries;

public class ObterItemPedidoQuery : IRequest<ItemPedido>
{
    public Guid Id { get; set; }
}
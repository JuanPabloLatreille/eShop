using Domain.Pedidos;
using MediatR;

namespace Application.ItensPedidos.Commands;

public class AddItemPedidoCommand : IRequest<ItemPedido>
{
    public Guid PedidoId { get; set; }
    public Guid ProdutoId { get; set; }
    public decimal Quantidade { get; set; }
    public decimal Valor { get; set; }
}
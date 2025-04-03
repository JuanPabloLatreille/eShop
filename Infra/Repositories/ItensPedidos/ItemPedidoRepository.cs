using Application.Interfaces.ItensPedidos;
using Domain.Pedidos;
using Infra.ApplicationContext;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories.ItensPedidos;

public class ItemPedidoRepository : IItemPedidoRepository
{
    private readonly AppDbContext _context;

    public ItemPedidoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ItemPedido>> ObterItensPedidoAsync()
    {
        return await _context.ItemPedidos
            .OrderBy(ip => ip.Id)
            .ToListAsync();
    }

    public async Task<ItemPedido?> ObterItemPedidoPorIdAsync(Guid id)
    {
        return await _context.ItemPedidos
            .FirstOrDefaultAsync(ip => ip.Id == id);
    }

    public async Task<List<ItemPedido>> ObterItensPorPedidoIdAsync(Guid pedidoId)
    {
        return await _context.ItemPedidos
            .Where(ip => ip.PedidoId == pedidoId)
            .OrderBy(ip => ip.Id)
            .ToListAsync();
    }

    public async Task<ItemPedido> AdicionarItemPedidoAsync(ItemPedido itemPedido)
    {
        await _context.ItemPedidos.AddAsync(itemPedido);
        await _context.SaveChangesAsync();

        return itemPedido;
    }

    public async Task DeletarItemPedidoAsync(ItemPedido itemPedido)
    {
        _context.ItemPedidos.Remove(itemPedido);
        await _context.SaveChangesAsync();
    }
}
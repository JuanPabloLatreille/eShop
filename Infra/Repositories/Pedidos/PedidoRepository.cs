using Application.Interfaces.Pedidos;
using Domain.Commons;
using Domain.Pedidos;
using Infra.ApplicationContext;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories.Pedidos;

public class PedidoRepository : IPedidoRepository
{
    private readonly AppDbContext _context;

    public PedidoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Pedido>> ObterPedidosAsync()
    {
        return await _context
            .Pedidos
            .Include(p => p.Itens)
            .ToListAsync();
    }

    public async Task<Pedido?> ObterPedidoIdAsync(Guid id)
    {
        return await _context.Pedidos.Include(p => p.Itens).FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Pedido?> ObterPedidoClienteIdAsync(Guid id)
    {
        return await _context.Pedidos.Where(x => x.Aberto).FirstOrDefaultAsync(p => p.ClienteId == id);
    }

    public async Task<Pedido> AdicionarPedidoAsync(Pedido pedido)
    {
        await _context.Pedidos.AddAsync(pedido);
        await _context.SaveChangesAsync();

        return pedido;
    }

    public async Task DeletarPedidoAsync(Pedido pedido)
    {
        _context.Pedidos.Remove(pedido);
        await _context.SaveChangesAsync();
    }

    public async Task<Result> FecharPedidoAsync(Pedido pedido)
    {
        var pedidoresult = Pedido.FecharPedido(pedido);

        if (!pedidoresult.Success)
        {
            return Result.Fail(pedidoresult.Message);
        }

        _context.Pedidos.Update(pedido);
        await _context.SaveChangesAsync();
        
        return Result.Ok();
    }
}
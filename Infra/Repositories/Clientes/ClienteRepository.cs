using Application.Interfaces.Clientes;
using Domain.Clientes;
using Infra.ApplicationContext;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories.Clientes;

public class ClienteRepository : IClienteRepository
{
    private readonly AppDbContext _context;

    public ClienteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Cliente> AdicionarClienteAsync(Cliente cliente)
    {
        await _context.Clientes.AddAsync(cliente);
        await _context.SaveChangesAsync();

        return cliente;
    }

    public async Task DeletarClienteAsync(Cliente cliente)
    {
        _context.Clientes.Remove(cliente);
        await _context.SaveChangesAsync();
    }

    public async Task<Cliente?> ObterClienteIdAsync(Guid id)
    {
        return await _context.Clientes
            .FirstOrDefaultAsync(c => c.Id.Equals(id));
    }

    public async Task<List<Cliente>> ObterClientesAsync()
    {
        return await _context.Clientes.OrderBy(c => c.DataCriacao).ToListAsync();
    }
}
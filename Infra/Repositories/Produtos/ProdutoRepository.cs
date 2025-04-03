using Application.Interfaces.Produtos;
using Domain.Produtos;
using Infra.ApplicationContext;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories.Produtos;

public class ProdutoRepository : IProdutoRepository
{
    private readonly AppDbContext _context;

    public ProdutoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Produto>> ObterProdutosAsync()
    {
        return await _context.Produtos.ToListAsync();
    }

    public async Task<Produto?> ObterProdutoIdAsync(Guid id)
    {
        return await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Produto> AdicionarProdutoAsync(Produto produto)
    {
        await _context.Produtos.AddAsync(produto);
        await _context.SaveChangesAsync();

        return produto;
    }

    public async Task DeletarProdutoAsync(Produto produto)
    {
        _context.Produtos.Remove(produto);
        await _context.SaveChangesAsync();
    }
}
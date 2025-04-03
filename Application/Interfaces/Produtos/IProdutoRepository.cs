using Domain.Produtos;

namespace Application.Interfaces.Produtos;

public interface IProdutoRepository
{
    Task<List<Produto>> ObterProdutosAsync();
    
    Task<Produto?> ObterProdutoIdAsync(Guid id);
    
    Task<Produto> AdicionarProdutoAsync(Produto produto);
    
    Task DeletarProdutoAsync(Produto produto);
}
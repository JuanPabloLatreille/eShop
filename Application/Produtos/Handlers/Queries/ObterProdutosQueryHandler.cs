using Application.Interfaces.Produtos;
using Application.Produtos.Queries;
using Domain.Produtos;
using MediatR;

namespace Application.Produtos.Handlers.Queries;

public class ObterProdutosQueryHandler : IRequestHandler<ObterProdutosQuery, List<Produto>>
{
    private readonly IProdutoRepository _produtoRepository;

    public ObterProdutosQueryHandler(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<List<Produto>> Handle(ObterProdutosQuery request, CancellationToken cancellationToken)
    {
        return await _produtoRepository.ObterProdutosAsync();
    }
}
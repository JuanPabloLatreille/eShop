using Application.Interfaces.Produtos;
using Domain.Commons;
using Domain.Produtos;
using MediatR;

namespace Application.Produtos.Queries;

public class ObterProdutosQuery : IRequest<Result<List<Produto>>>;

public class ObterProdutosQueryHandler : IRequestHandler<ObterProdutosQuery, Result<List<Produto>>>
{
    private readonly IProdutoRepository _produtoRepository;

    public ObterProdutosQueryHandler(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<Result<List<Produto>>> Handle(ObterProdutosQuery request, CancellationToken cancellationToken)
    {
        return Result<List<Produto>>.Ok(await _produtoRepository.ObterProdutosAsync());
    }
}
using Application.Interfaces.Produtos;
using Application.Produtos.Queries;
using Domain.Produtos;
using MediatR;

namespace Application.Produtos.Handlers.Queries;

public class ObterProdutoQueryHandler : IRequestHandler<ObterProdutoQuery, Produto>
{
    private readonly IProdutoRepository _repository;

    public ObterProdutoQueryHandler(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Produto> Handle(ObterProdutoQuery request, CancellationToken cancellationToken)
    {
        var produto = await _repository.ObterProdutoIdAsync(request.Id);

        if (produto is null)
        {
            throw new Exception("Produto não encontrado.");
        }
        
        return produto;
    }
}
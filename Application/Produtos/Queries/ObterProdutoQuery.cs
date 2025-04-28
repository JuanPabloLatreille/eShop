using Application.Interfaces.Produtos;
using Domain.Commons;
using Domain.Produtos;
using MediatR;

namespace Application.Produtos.Queries;

public class ObterProdutoQuery : IRequest<Result<Produto>>
{
    public Guid Id { get; set; }
}

public class ObterProdutoQueryHandler : IRequestHandler<ObterProdutoQuery, Result<Produto>>
{
    private readonly IProdutoRepository _repository;

    public ObterProdutoQueryHandler(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Produto>> Handle(ObterProdutoQuery request, CancellationToken cancellationToken)
    {
        var produto = await _repository.ObterProdutoIdAsync(request.Id);

        if (produto is null)
        {
            return Result<Produto>.NotFound("Produto não encontrado.");
        }

        return Result<Produto>.Ok(produto);
    }
}
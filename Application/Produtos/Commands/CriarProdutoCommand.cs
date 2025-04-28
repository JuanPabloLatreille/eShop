using Application.Interfaces.Produtos;
using Domain.Commons;
using Domain.Produtos;
using MediatR;

namespace Application.Produtos.Commands;

public class CriarProdutoCommand : IRequest<Result<Produto>>
{
    public required string Nome { get; set; }

    public required string Descricao { get; set; }

    public required decimal ValorUnitario { get; set; }

    public required decimal Quantidade { get; set; }
}

public class CriarProdutoCommandHandler : IRequestHandler<CriarProdutoCommand, Result<Produto>>
{
    private readonly IProdutoRepository _repository;

    public CriarProdutoCommandHandler(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Produto>> Handle(CriarProdutoCommand request, CancellationToken cancellationToken)
    {
        var produtoResult = Produto.CriarProduto(
            request.Nome,
            request.Descricao,
            request.ValorUnitario,
            request.Quantidade);

        if (!produtoResult.Success)
        {
            return produtoResult;
        }
        
        var produto = produtoResult.Data!;
        
        await _repository.AdicionarProdutoAsync(produto);

        return produtoResult;
    }
}
using Application.Interfaces.Produtos;
using Application.Produtos.Commands;
using Domain.Produtos;
using MediatR;

namespace Application.Produtos.Handlers.Commands;

public class CriarProdutoCommandHandler : IRequestHandler<CriarProdutoCommand, Produto>
{
    private readonly IProdutoRepository _repository;

    public CriarProdutoCommandHandler(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Produto> Handle(CriarProdutoCommand request, CancellationToken cancellationToken)
    {
        var produto = Produto.CriarProduto(request.Nome, request.Descricao, request.ValorUnitario, request.Quantidade);
        await _repository.AdicionarProdutoAsync(produto);

        return produto;
    }
}
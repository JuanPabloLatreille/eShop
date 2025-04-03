using Application.Interfaces.Produtos;
using Application.Produtos.Commands;
using MediatR;

namespace Application.Produtos.Handlers.Commands;

public class DeletarProdutoCommandHandler : IRequestHandler<DeletarProdutoCommand>
{
    private readonly IProdutoRepository _repository;

    public DeletarProdutoCommandHandler(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeletarProdutoCommand request, CancellationToken cancellationToken)
    {
        var produto = await _repository.ObterProdutoIdAsync(request.Id);

        if (produto == null)
        {
            throw new Exception("Produto não encontrado.");
        }

        await _repository.DeletarProdutoAsync(produto);
    }
}
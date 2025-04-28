using Application.Interfaces.Produtos;
using Domain.Commons;
using MediatR;

namespace Application.Produtos.Commands;

public class DeletarProdutoCommand : IRequest<Result>
{
    public Guid Id { get; set; }
}

public class DeletarProdutoCommandHandler : IRequestHandler<DeletarProdutoCommand, Result>
{
    private readonly IProdutoRepository _repository;

    public DeletarProdutoCommandHandler(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(DeletarProdutoCommand request, CancellationToken cancellationToken)
    {
        var produto = await _repository.ObterProdutoIdAsync(request.Id);

        if (produto == null)
        {
            return Result.NotFound("Produto não encontrado.");
        }

        await _repository.DeletarProdutoAsync(produto);

        return Result.Ok();
    }
}
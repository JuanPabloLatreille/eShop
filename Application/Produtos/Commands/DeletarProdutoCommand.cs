using MediatR;

namespace Application.Produtos.Commands;

public class DeletarProdutoCommand : IRequest
{
    public Guid Id { get; set; }
}
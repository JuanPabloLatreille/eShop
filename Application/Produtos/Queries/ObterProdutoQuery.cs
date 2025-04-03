using Domain.Produtos;
using MediatR;

namespace Application.Produtos.Queries;

public class ObterProdutoQuery : IRequest<Produto>
{
    public Guid Id { get; set; }
}

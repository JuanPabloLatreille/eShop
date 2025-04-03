using Domain.Produtos;
using MediatR;

namespace Application.Produtos.Queries;

public class ObterProdutosQuery : IRequest<List<Produto>>
{
    
}
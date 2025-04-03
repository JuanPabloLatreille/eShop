using Domain.Produtos;
using MediatR;

namespace Application.Produtos.Commands;

public class CriarProdutoCommand : IRequest<Produto>
{
    public required string Nome { get; set; }

    public required string Descricao { get; set; }

    public required decimal ValorUnitario { get; set; }

    public required decimal Quantidade { get; set; }
}
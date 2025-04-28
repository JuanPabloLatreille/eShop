using Domain.Commons;

namespace Domain.Produtos;

public sealed class Produto
{
    private Produto(Guid id, string nome, string descricao, decimal valorUnitario, decimal quantidade)
    {
        Id = id;
        Nome = nome;
        Descricao = descricao;
        ValorUnitario = valorUnitario;
        Quantidade = quantidade;
    }

    public Guid Id { get; private set; }

    public string Nome { get; private set; }

    public string Descricao { get; private set; }

    public decimal ValorUnitario { get; private set; }

    public decimal Quantidade { get; private set; }

    public static Result<Produto> CriarProduto(string nome, string descricao, decimal valorUnitario, decimal quantidade)
    {
        if (string.IsNullOrEmpty(nome))
        {
            return Result<Produto>.BadRequest("Nome é obrigatório.");
        }

        if (string.IsNullOrEmpty(descricao))
        {
            return Result<Produto>.BadRequest("Descrição é obrigatório.");
        }

        if (valorUnitario < 0)
        {
            return Result<Produto>.BadRequest("Valor inválido.");
        }

        if (quantidade < 0)
        {
            return Result<Produto>.BadRequest("Quantidade inválida.");
        }

        return Result<Produto>.Created(new Produto(Guid.NewGuid(), nome, descricao, valorUnitario, quantidade));
    }
}
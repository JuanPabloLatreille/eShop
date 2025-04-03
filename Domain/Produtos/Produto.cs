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

    public static Produto CriarProduto(string nome, string descricao, decimal valorUnitario, decimal quantidade)
    {
        return new Produto(Guid.NewGuid(), nome, descricao, valorUnitario, quantidade);
    }
}
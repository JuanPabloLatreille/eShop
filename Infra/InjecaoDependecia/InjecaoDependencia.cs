using Application.Clientes.Queries;
using Application.Interfaces.Clientes;
using Application.Interfaces.ItensPedidos;
using Application.Interfaces.Pedidos;
using Application.Interfaces.Produtos;
using Application.Pedidos.Handlers.Queries;
using Infra.Repositories.Clientes;
using Infra.Repositories.ItensPedidos;
using Infra.Repositories.Pedidos;
using Infra.Repositories.Produtos;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.InjecaoDependecia;

public static class InjecaoDependencia
{
    public static IServiceCollection AdicionarInjecao(this IServiceCollection services)
    {
        var assemblyApplication = typeof(ObterClientesQuery).Assembly;

        services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assemblyApplication));
        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddScoped<IPedidoRepository, PedidoRepository>();
        services.AddScoped<IItemPedidoRepository, ItemPedidoRepository>();

        return services;
    }
}
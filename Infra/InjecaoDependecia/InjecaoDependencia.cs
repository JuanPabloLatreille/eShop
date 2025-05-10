using Application.Clientes.Queries;
using Application.Clientes.Validators;
using Application.Interfaces.Clientes;
using Application.Interfaces.ItensPedidos;
using Application.Interfaces.Pedidos;
using Application.Interfaces.Produtos;
using Application.Interfaces.TokenService;
using Application.Interfaces.Usuarios;
using FluentValidation;
using Infra.Repositories.Clientes;
using Infra.Repositories.ItensPedidos;
using Infra.Repositories.Pedidos;
using Infra.Repositories.Produtos;
using Infra.Repositories.Usuarios;
using Infra.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.InjecaoDependecia;

public static class InjecaoDependencia
{
    public static IServiceCollection AdicionarInjecao(this IServiceCollection services)
    {
        var assemblyApplication = typeof(ObterClientesQuery).Assembly;

        services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assemblyApplication));
        services.AddValidatorsFromAssembly(typeof(CriarClienteCommandValidator).Assembly);
        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddScoped<IPedidoRepository, PedidoRepository>();
        services.AddScoped<IItemPedidoRepository, ItemPedidoRepository>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<ITokenService, TokenService>();

        return services;
    }
}
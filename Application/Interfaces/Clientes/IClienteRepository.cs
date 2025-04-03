using Domain.Clientes;

namespace Application.Interfaces.Clientes;

public interface IClienteRepository
{
    Task<List<Cliente>> ObterClientesAsync();

    Task<Cliente?> ObterClienteIdAsync(Guid id);

    Task<Cliente> AdicionarClienteAsync(Cliente cliente);

    Task DeletarClienteAsync(Cliente cliente);
}
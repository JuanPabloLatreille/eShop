using Domain.Usuarios;

namespace Application.Interfaces.Usuarios;

public interface IUsuarioRepository
{
    Task<Usuario> AdicionarUsuarioAsync(Usuario usuario);

    Task<Usuario?> BuscarUsuarioNomeAsync(string nome);
}
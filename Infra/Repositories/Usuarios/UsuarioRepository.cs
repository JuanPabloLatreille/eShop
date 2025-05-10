using Application.Interfaces.Usuarios;
using Domain.Usuarios;
using Infra.ApplicationContext;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories.Usuarios;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext _context;

    public UsuarioRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Usuario> AdicionarUsuarioAsync(Usuario usuario)
    {
        await _context.AddAsync(usuario);
        await _context.SaveChangesAsync();

        return usuario;
    }

    public async Task<Usuario?> BuscarUsuarioNomeAsync(string nome)
    {
        return await _context.Usuarios
            .Where(x => x.Nome.Equals(nome))
            .FirstOrDefaultAsync();
    }
}
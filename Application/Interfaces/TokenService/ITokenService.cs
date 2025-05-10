using Domain.Usuarios;

namespace Infra.Services.Interfaces;

public interface ITokenService
{
    public string GerarToken(Usuario  usuario);
}
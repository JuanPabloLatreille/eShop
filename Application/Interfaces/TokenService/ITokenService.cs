using Domain.Usuarios;

namespace Application.Interfaces.TokenService;

public interface ITokenService
{
    public string GerarToken(Usuario  usuario);
}
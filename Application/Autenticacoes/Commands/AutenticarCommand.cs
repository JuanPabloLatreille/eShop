using Application.Interfaces.TokenService;
using Application.Interfaces.Usuarios;
using Domain.Commons;
using MediatR;

namespace Application.Autenticacoes.Commands;

public class AutenticarCommand : IRequest<Result<string>>
{
    public string Usuario { get; set; } = string.Empty;

    public string Senha { get; set; } = string.Empty;
}

public class AutenticarCommandHandler : IRequestHandler<AutenticarCommand, Result<string>>
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly ITokenService _tokenService;

    public AutenticarCommandHandler(IUsuarioRepository usuarioRepository, ITokenService tokenService)
    {
        _usuarioRepository = usuarioRepository;
        _tokenService = tokenService;
    }

    public async Task<Result<string>> Handle(AutenticarCommand request, CancellationToken cancellationToken)
    {
        var usuario = await _usuarioRepository.BuscarUsuarioNomeAsync(request.Usuario);

        if (usuario is null)
        {
            return Result<string>.NotFound("Usuário não encontrado.");
        }

        bool senhaCorreta = BCrypt.Net.BCrypt.Verify(request.Senha, usuario.Senha);

        if (!senhaCorreta)
        {
            return Result<string>.Unauthorized("Credenciais inválidas.");
        }

        var token = _tokenService.GerarToken(usuario);

        return Result<string>.Ok(token);
    }
}
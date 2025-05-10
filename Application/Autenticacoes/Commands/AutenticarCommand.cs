using Application.Interfaces.TokenService;
using Application.Interfaces.Usuarios;
using Domain.Commons;
using MediatR;

namespace Application.Autenticacoes.Commands;

public class AutenticarCommand : IRequest<Result<Autenticacao>>
{
    public string Usuario { get; set; } = string.Empty;

    public string Senha { get; set; } = string.Empty;
}

public class AutenticarCommandHandler : IRequestHandler<AutenticarCommand, Result<Autenticacao>>
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly ITokenService _tokenService;

    public AutenticarCommandHandler(IUsuarioRepository usuarioRepository, ITokenService tokenService)
    {
        _usuarioRepository = usuarioRepository;
        _tokenService = tokenService;
    }

    public async Task<Result<Autenticacao>> Handle(AutenticarCommand request, CancellationToken cancellationToken)
    {
        var usuario = await _usuarioRepository.BuscarUsuarioNomeAsync(request.Usuario);

        if (usuario is null)
        {
            return Result<Autenticacao>.NotFound("Usuário não encontrado.");
        }

        var senhaCorreta = BCrypt.Net.BCrypt.Verify(request.Senha, usuario.Senha);

        if (!senhaCorreta)
        {
            return Result<Autenticacao>.Unauthorized("Credenciais inválidas.");
        }

        var token = _tokenService.GerarToken(usuario);

        return Autenticacao.Criar(Guid.NewGuid(), usuario.Id, token);
    }
}
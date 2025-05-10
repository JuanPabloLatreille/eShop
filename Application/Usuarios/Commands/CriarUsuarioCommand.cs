using Application.Interfaces.Usuarios;
using Domain.Commons;
using Domain.Usuarios;
using MediatR;

namespace Application.Usuarios.Commands;

public class CriarUsuarioCommand : IRequest<Result<Usuario>>
{
    public string Nome { get; set; } = string.Empty;

    public string Senha { get; set; } = string.Empty;
}

public class CriarUsuarioCommandHandler : IRequestHandler<CriarUsuarioCommand, Result<Usuario>>
{
    private readonly IUsuarioRepository _usuarioRepository;

    public CriarUsuarioCommandHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<Result<Usuario>> Handle(CriarUsuarioCommand request, CancellationToken cancellationToken)
    {
        var userResult = Usuario.Create(request.Nome, request.Senha);

        if (!userResult.Success)
        {
            return userResult;
        }

        var usuarioData = userResult.Data!;

        var usuario = await _usuarioRepository.AdicionarUsuarioAsync(usuarioData);

        return Result<Usuario>.Created(usuario);
    }
}
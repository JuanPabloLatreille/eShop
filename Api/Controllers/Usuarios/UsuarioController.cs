using Application.Usuarios.Commands;
using Domain.Commons;
using Domain.Usuarios;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Usuarios;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsuarioController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<Result<Usuario>>> PostTaskAsync([FromBody] CriarUsuarioCommand command)
    {
        if (command == null)
        {
            return BadRequest("Comando inválido");
        }

        var usuario = await _mediator.Send(command);
        return Ok(usuario);
    }
}
using Application.Autenticacoes.Commands;
using Domain.Commons;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Autenticacoes;

[Route("api/[controller]")]
[ApiController]
public class AutenticacaoController : ControllerBase
{
    private readonly IMediator _mediator;

    public AutenticacaoController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<ActionResult<Result<Autenticacao>>> PostTaskAsync([FromBody] AutenticarCommand command)
    {
        if (command == null)
        {
            return BadRequest("Comando inválido");
        }

        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
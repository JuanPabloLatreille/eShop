using Application.Clientes.Commands;
using Application.Clientes.Queries;
using Domain.Clientes;
using Domain.Commons;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Clientes;

[Route("api/[controller]")]
[ApiController]
public class ClienteController : ControllerBase
{
    private readonly IMediator _mediator;

    public ClienteController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<Result<List<Cliente>>>> GetTaskAsync()
    {
        return await _mediator.Send(new ObterClientesQuery());
    }

    [HttpGet("Id")]
    public async Task<ActionResult<Result<Cliente>>> GetTaskAsync([FromQuery] ObterClienteQuery query)
    {
        return await _mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<Result<Cliente>>> PostTaskAsync([FromBody] CriarClienteCommand command)
    {
        if (command == null)
        {
            return BadRequest("Comando inválido");
        }

        var cliente = await _mediator.Send(command);
        return Ok(cliente);
    }

    [HttpDelete]
    public async Task<ActionResult<Result>> DeleteTaskAsync([FromBody] DeletarClienteCommand command)
    {
        if (command == null)
        {
            return BadRequest("Comando inválido");
        }

        return await _mediator.Send(command);
    }
}
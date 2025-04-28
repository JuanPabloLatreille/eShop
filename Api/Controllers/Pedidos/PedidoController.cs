using Application.Pedidos.Commands;
using Application.Pedidos.Queries;
using Domain.Commons;
using Domain.Pedidos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Pedidos;

[Route("api/[controller]")]
[ApiController]
public class PedidoController : ControllerBase
{
    private readonly IMediator _mediator;

    public PedidoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<Result<List<Pedido>>>> GetTaskAsync()
    {
        return await _mediator.Send(new ObterPedidosQuery());
    }

    [HttpGet("Id")]
    public async Task<ActionResult<Result<Pedido>>> GetTaskAsync([FromQuery] ObterPedidoQuery query)
    {
        return await _mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<Result<Pedido>>> PostTaskAsync([FromBody] CriarPedidoCommand command)
    {
        var result = await _mediator.Send(command);

        return StatusCode((int)result.StatusCode, result);
    }

    [HttpPut]
    public async Task<ActionResult<Result>> PutTaskAsync([FromBody] FecharPedidoCommand command)
    {
        if (command == null)
        {
            return BadRequest("Comando inválido");
        }
        
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete]
    public async Task<ActionResult<Result>> DeleteTaskAsync([FromBody] DeletarPedidoCommand command)
    {
        if (command == null)
        {
            return BadRequest("Comando inválido");
        }

        await _mediator.Send(command);

        return Ok();
    }
}
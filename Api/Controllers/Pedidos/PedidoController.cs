using Application.Pedidos.Commands;
using Application.Pedidos.Queries;
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
    public async Task<ActionResult<List<Pedido>>> GetTaskAsync()
    {
        return await _mediator.Send(new ObterPedidosQuery());
    }

    [HttpGet("Id")]
    public async Task<ActionResult<Pedido>> GetTaskAsync([FromQuery] ObterPedidoQuery query)
    {
        return await _mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<Pedido>> PostTaskAsync([FromBody] CriarPedidoCommand command)
    {
        if (command == null)
        {
            return BadRequest("Comando inválido");
        }

        var pedido = await _mediator.Send(command);
        return Ok(pedido);
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteTaskAsync([FromBody] DeletarPedidoCommand command)
    {
        if (command == null)
        {
            return BadRequest("Comando inválido");
        }

        await _mediator.Send(command);

        return Ok();
    }
}
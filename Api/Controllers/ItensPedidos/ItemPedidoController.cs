using Application.ItensPedidos.Commands;
using Application.ItensPedidos.Queries;
using Domain.Commons;
using Domain.Pedidos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.ItensPedidos;

[Route("api/[controller]")]
[ApiController]
public class ItemPedidoController : ControllerBase
{
    private readonly IMediator _mediator;

    public ItemPedidoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<Result<List<ItemPedido>>>> GetTaskAsync()
    {
        return await _mediator.Send(new ObterItensPedidosQuery());
    }

    [HttpGet("Id")]
    public async Task<ActionResult<Result<ItemPedido>>> GetTaskAsync([FromQuery] ObterItemPedidoQuery query)
    {
        var item = await _mediator.Send(query);

        return Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<Result<ItemPedido>>> PostTaskAsync([FromBody] AddItemPedidoCommand command)
    {
        if (command == null)
            return BadRequest("Comando inválido");

        var item = await _mediator.Send(command);
        return Ok(item);
    }
}
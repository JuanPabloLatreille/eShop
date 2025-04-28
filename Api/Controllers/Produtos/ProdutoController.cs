using Application.Produtos.Commands;
using Application.Produtos.Queries;
using Domain.Commons;
using Domain.Produtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Produtos;

[Route("api/[controller]")]
[ApiController]
public class ProdutoController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProdutoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<Result<List<Produto>>>> GetTaskAsync()
    {
        return await _mediator.Send(new ObterProdutosQuery());
    }

    [HttpGet("Id")]
    public async Task<ActionResult<Result<Produto>>> GetTaskAsync([FromQuery] ObterProdutoQuery query)
    {
        return await _mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<Result<Produto>>> PostTaskAsync([FromBody] CriarProdutoCommand command)
    {
        if (command == null)
        {
            return BadRequest("Comando inválido");
        }

        var produto = await _mediator.Send(command);
        return Ok(produto);
    }

    [HttpDelete]
    public async Task<ActionResult<Result>> DeleteTaskAsync([FromBody] DeletarProdutoCommand command)
    {
        if (command == null)
        {
            return BadRequest("Comando inválido");
        }

        await _mediator.Send(command);

        return Ok();
    }
}
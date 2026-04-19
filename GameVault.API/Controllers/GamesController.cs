using GameVault.Application.Games.Commands;
using GameVault.Application.Games.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameVault.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GamesController : ControllerBase
{
    private readonly IMediator _mediator;
    public GamesController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _mediator.Send(new GetAllGamesQuery()));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var game = await _mediator.Send(new GetGameByIdQuery(id));
        return game == null ? NotFound() : Ok(game);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateGameCommand command) =>
        CreatedAtAction(nameof(GetById), new { id = 0 }, await _mediator.Send(command));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateGameCommand command)
    {
        if (id != command.Id) return BadRequest();
        var game = await _mediator.Send(command);
        return game == null ? NotFound() : Ok(game);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) =>
        await _mediator.Send(new DeleteGameCommand(id)) ? NoContent() : NotFound();
}
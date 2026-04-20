using GameVault.Application.Genres.Commands;
using GameVault.Application.Genres.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameVault.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenresController : ControllerBase
{
    private readonly IMediator _mediator;
    public GenresController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _mediator.Send(new GetAllGenresQuery()));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var genre = await _mediator.Send(new GetGenreByIdQuery(id));
        return genre == null ? NotFound() : Ok(genre);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateGenreCommand command) =>
        CreatedAtAction(nameof(GetById), new { id = 0 }, await _mediator.Send(command));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateGenreCommand command)
    {
        if (id != command.Id) return BadRequest();
        return Ok(await _mediator.Send(command));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) =>
        await _mediator.Send(new DeleteGenreCommand(id)) ? NoContent() : NotFound();
}
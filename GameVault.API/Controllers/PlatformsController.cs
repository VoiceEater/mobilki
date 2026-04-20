using GameVault.Application.Platforms.Commands;
using GameVault.Application.Platforms.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameVault.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlatformsController : ControllerBase
{
    private readonly IMediator _mediator;
    public PlatformsController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _mediator.Send(new GetAllPlatformsQuery()));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var platform = await _mediator.Send(new GetPlatformByIdQuery(id));
        return platform == null ? NotFound() : Ok(platform);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePlatformCommand command) =>
        CreatedAtAction(nameof(GetById), new { id = 0 }, await _mediator.Send(command));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdatePlatformCommand command)
    {
        if (id != command.Id) return BadRequest();
        return Ok(await _mediator.Send(command));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) =>
        await _mediator.Send(new DeletePlatformCommand(id)) ? NoContent() : NotFound();
}
using GameVault.Application.Publishers.Commands;
using GameVault.Application.Publishers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameVault.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PublishersController : ControllerBase
{
    private readonly IMediator _mediator;
    public PublishersController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _mediator.Send(new GetAllPublishersQuery()));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var publisher = await _mediator.Send(new GetPublisherByIdQuery(id));
        return publisher == null ? NotFound() : Ok(publisher);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePublisherCommand command) =>
        CreatedAtAction(nameof(GetById), new { id = 0 }, await _mediator.Send(command));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdatePublisherCommand command)
    {
        if (id != command.Id) return BadRequest();
        return Ok(await _mediator.Send(command));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) =>
        await _mediator.Send(new DeletePublisherCommand(id)) ? NoContent() : NotFound();
}
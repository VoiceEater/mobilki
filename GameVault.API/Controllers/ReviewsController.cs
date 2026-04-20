using GameVault.Application.Reviews.Commands;
using GameVault.Application.Reviews.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameVault.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewsController : ControllerBase
{
    private readonly IMediator _mediator;
    public ReviewsController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _mediator.Send(new GetAllReviewsQuery()));

    [HttpGet("game/{gameId}")]
    public async Task<IActionResult> GetByGameId(int gameId) =>
        Ok(await _mediator.Send(new GetReviewsByGameIdQuery(gameId)));

    [HttpPost]
    public async Task<IActionResult> Create(CreateReviewCommand command) =>
        CreatedAtAction(nameof(GetAll), await _mediator.Send(command));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateReviewCommand command)
    {
        if (id != command.Id) return BadRequest();
        var review = await _mediator.Send(command);
        return review == null ? NotFound() : Ok(review);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) =>
        await _mediator.Send(new DeleteReviewCommand(id)) ? NoContent() : NotFound();
}
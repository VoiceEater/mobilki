using GameVault.Application.Wishlists.Commands;
using GameVault.Application.Wishlists.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameVault.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WishlistsController : ControllerBase
{
    private readonly IMediator _mediator;
    public WishlistsController(IMediator mediator) => _mediator = mediator;

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetByUserId(int userId) =>
        Ok(await _mediator.Send(new GetWishlistByUserIdQuery(userId)));

    [HttpPost]
    public async Task<IActionResult> Add(AddToWishlistCommand command) =>
        CreatedAtAction(nameof(GetByUserId), new { userId = command.UserId }, await _mediator.Send(command));

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove(int id) =>
        await _mediator.Send(new RemoveFromWishlistCommand(id)) ? NoContent() : NotFound();
}
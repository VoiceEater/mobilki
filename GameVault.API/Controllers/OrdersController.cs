using GameVault.Application.Orders.Commands;
using GameVault.Application.Orders.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameVault.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;
    public OrdersController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _mediator.Send(new GetAllOrdersQuery()));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var order = await _mediator.Send(new GetOrderByIdQuery(id));
        return order == null ? NotFound() : Ok(order);
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetByUserId(int userId) =>
        Ok(await _mediator.Send(new GetOrdersByUserIdQuery(userId)));

    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderCommand command) =>
        CreatedAtAction(nameof(GetById), new { id = 0 }, await _mediator.Send(command));

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) =>
        await _mediator.Send(new DeleteOrderCommand(id)) ? NoContent() : NotFound();
}
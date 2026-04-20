using GameVault.Application.Orders.Commands;
using GameVault.Domain.Entities;
using GameVault.Infrastructure.Data;
using MediatR;

namespace GameVault.Infrastructure.Orders.Commands;

public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Order>
{
    private readonly AppDbContext _db;
    public CreateOrderHandler(AppDbContext db) => _db = db;

    public async Task<Order> Handle(CreateOrderCommand request, CancellationToken ct)
    {
        var order = new Order
        {
            UserId = request.UserId,
            OrderDate = DateTime.UtcNow,
            OrderItems = request.Items.Select(i => new OrderItem
            {
                GameId = i.GameId,
                Quantity = i.Quantity,
                UnitPrice = i.UnitPrice
            }).ToList()
        };
        order.TotalAmount = order.OrderItems.Sum(i => i.Quantity * i.UnitPrice);

        _db.Orders.Add(order);
        await _db.SaveChangesAsync(ct);
        return order;
    }
}
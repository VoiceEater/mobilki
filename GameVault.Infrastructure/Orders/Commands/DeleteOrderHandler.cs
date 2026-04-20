using GameVault.Application.Orders.Commands;
using GameVault.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameVault.Infrastructure.Orders.Commands;

public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand, bool>
{
    private readonly AppDbContext _db;
    public DeleteOrderHandler(AppDbContext db) => _db = db;

    public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken ct)
    {
        var order = await _db.Orders
            .Include(o => o.OrderItems)
            .FirstOrDefaultAsync(o => o.Id == request.Id, ct);
        if (order == null) return false;
        _db.Orders.Remove(order);
        await _db.SaveChangesAsync(ct);
        return true;
    }
}
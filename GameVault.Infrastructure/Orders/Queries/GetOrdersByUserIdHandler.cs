using GameVault.Application.Orders.Queries;
using GameVault.Domain.Entities;
using GameVault.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameVault.Infrastructure.Orders.Queries;

public class GetOrdersByUserIdHandler : IRequestHandler<GetOrdersByUserIdQuery, List<Order>>
{
    private readonly AppDbContext _db;
    public GetOrdersByUserIdHandler(AppDbContext db) => _db = db;

    public async Task<List<Order>> Handle(GetOrdersByUserIdQuery request, CancellationToken ct)
    {
        return await _db.Orders
            .Where(o => o.UserId == request.UserId)
            .Include(o => o.OrderItems).ThenInclude(oi => oi.Game)
            .ToListAsync(ct);
    }
}
using GameVault.Application.Orders.Queries;
using GameVault.Domain.Entities;
using GameVault.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameVault.Infrastructure.Orders.Queries;

public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, List<Order>>
{
    private readonly AppDbContext _db;
    public GetAllOrdersHandler(AppDbContext db) => _db = db;

    public async Task<List<Order>> Handle(GetAllOrdersQuery request, CancellationToken ct)
    {
        return await _db.Orders
            .Include(o => o.User)
            .Include(o => o.OrderItems).ThenInclude(oi => oi.Game)
            .ToListAsync(ct);
    }
}
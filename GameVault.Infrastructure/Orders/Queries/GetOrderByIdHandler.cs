using GameVault.Application.Orders.Queries;
using GameVault.Domain.Entities;
using GameVault.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameVault.Infrastructure.Orders.Queries;

public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, Order?>
{
    private readonly AppDbContext _db;
    public GetOrderByIdHandler(AppDbContext db) => _db = db;

    public async Task<Order?> Handle(GetOrderByIdQuery request, CancellationToken ct)
    {
        return await _db.Orders
            .Include(o => o.User)
            .Include(o => o.OrderItems).ThenInclude(oi => oi.Game)
            .FirstOrDefaultAsync(o => o.Id == request.Id, ct);
    }
}
using GameVault.Application.Wishlists.Queries;
using GameVault.Domain.Entities;
using GameVault.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameVault.Infrastructure.Wishlists.Queries;

public class GetWishlistByUserIdHandler : IRequestHandler<GetWishlistByUserIdQuery, List<WishlistItem>>
{
    private readonly AppDbContext _db;
    public GetWishlistByUserIdHandler(AppDbContext db) => _db = db;

    public async Task<List<WishlistItem>> Handle(GetWishlistByUserIdQuery request, CancellationToken ct)
    {
        return await _db.WishlistItems
            .Where(w => w.UserId == request.UserId)
            .Include(w => w.Game)
            .ToListAsync(ct);
    }
}
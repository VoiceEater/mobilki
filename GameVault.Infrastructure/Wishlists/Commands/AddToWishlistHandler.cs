using GameVault.Application.Wishlists.Commands;
using GameVault.Domain.Entities;
using GameVault.Infrastructure.Data;
using MediatR;

namespace GameVault.Infrastructure.Wishlists.Commands;

public class AddToWishlistHandler : IRequestHandler<AddToWishlistCommand, WishlistItem>
{
    private readonly AppDbContext _db;
    public AddToWishlistHandler(AppDbContext db) => _db = db;

    public async Task<WishlistItem> Handle(AddToWishlistCommand request, CancellationToken ct)
    {
        var item = new WishlistItem
        {
            UserId = request.UserId,
            GameId = request.GameId,
            AddedAt = DateTime.UtcNow
        };
        _db.WishlistItems.Add(item);
        await _db.SaveChangesAsync(ct);
        return item;
    }
}
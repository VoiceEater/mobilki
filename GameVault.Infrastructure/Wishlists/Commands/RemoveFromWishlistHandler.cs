using GameVault.Application.Wishlists.Commands;
using GameVault.Infrastructure.Data;
using MediatR;

namespace GameVault.Infrastructure.Wishlists.Commands;

public class RemoveFromWishlistHandler : IRequestHandler<RemoveFromWishlistCommand, bool>
{
    private readonly AppDbContext _db;
    public RemoveFromWishlistHandler(AppDbContext db) => _db = db;

    public async Task<bool> Handle(RemoveFromWishlistCommand request, CancellationToken ct)
    {
        var item = await _db.WishlistItems.FindAsync(new object[] { request.Id }, ct);
        if (item == null) return false;
        _db.WishlistItems.Remove(item);
        await _db.SaveChangesAsync(ct);
        return true;
    }
}
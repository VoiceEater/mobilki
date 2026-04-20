using GameVault.Application.Platforms.Commands;
using GameVault.Infrastructure.Data;
using MediatR;

namespace GameVault.Infrastructure.Platforms.Commands;

public class DeletePlatformHandler : IRequestHandler<DeletePlatformCommand, bool>
{
    private readonly AppDbContext _db;
    public DeletePlatformHandler(AppDbContext db) => _db = db;

    public async Task<bool> Handle(DeletePlatformCommand request, CancellationToken ct)
    {
        var platform = await _db.Platforms.FindAsync(new object[] { request.Id }, ct);
        if (platform == null) return false;
        _db.Platforms.Remove(platform);
        await _db.SaveChangesAsync(ct);
        return true;
    }
}
using GameVault.Application.Platforms.Commands;
using GameVault.Domain.Entities;
using GameVault.Infrastructure.Data;
using MediatR;

namespace GameVault.Infrastructure.Platforms.Commands;

public class UpdatePlatformHandler : IRequestHandler<UpdatePlatformCommand, Platform?>
{
    private readonly AppDbContext _db;
    public UpdatePlatformHandler(AppDbContext db) => _db = db;

    public async Task<Platform?> Handle(UpdatePlatformCommand request, CancellationToken ct)
    {
        var platform = await _db.Platforms.FindAsync(new object[] { request.Id }, ct);
        if (platform == null) return null;
        platform.Name = request.Name;
        await _db.SaveChangesAsync(ct);
        return platform;
    }
}
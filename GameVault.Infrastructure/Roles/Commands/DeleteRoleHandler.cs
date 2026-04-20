using GameVault.Application.Roles.Commands;
using GameVault.Infrastructure.Data;
using MediatR;

namespace GameVault.Infrastructure.Roles.Commands;

public class DeleteRoleHandler : IRequestHandler<DeleteRoleCommand, bool>
{
    private readonly AppDbContext _db;
    public DeleteRoleHandler(AppDbContext db) => _db = db;

    public async Task<bool> Handle(DeleteRoleCommand request, CancellationToken ct)
    {
        var role = await _db.Roles.FindAsync(new object[] { request.Id }, ct);
        if (role == null) return false;
        _db.Roles.Remove(role);
        await _db.SaveChangesAsync(ct);
        return true;
    }
}
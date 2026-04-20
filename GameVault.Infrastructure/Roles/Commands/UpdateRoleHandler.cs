using GameVault.Application.Roles.Commands;
using GameVault.Domain.Entities;
using GameVault.Infrastructure.Data;
using MediatR;

namespace GameVault.Infrastructure.Roles.Commands;

public class UpdateRoleHandler : IRequestHandler<UpdateRoleCommand, Role?>
{
    private readonly AppDbContext _db;
    public UpdateRoleHandler(AppDbContext db) => _db = db;

    public async Task<Role?> Handle(UpdateRoleCommand request, CancellationToken ct)
    {
        var role = await _db.Roles.FindAsync(new object[] { request.Id }, ct);
        if (role == null) return null;
        role.Name = request.Name;
        await _db.SaveChangesAsync(ct);
        return role;
    }
}
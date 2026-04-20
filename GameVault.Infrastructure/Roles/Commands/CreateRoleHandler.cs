using GameVault.Application.Roles.Commands;
using GameVault.Domain.Entities;
using GameVault.Infrastructure.Data;
using MediatR;

namespace GameVault.Infrastructure.Roles.Commands;

public class CreateRoleHandler : IRequestHandler<CreateRoleCommand, Role>
{
    private readonly AppDbContext _db;
    public CreateRoleHandler(AppDbContext db) => _db = db;

    public async Task<Role> Handle(CreateRoleCommand request, CancellationToken ct)
    {
        var role = new Role { Name = request.Name };
        _db.Roles.Add(role);
        await _db.SaveChangesAsync(ct);
        return role;
    }
}
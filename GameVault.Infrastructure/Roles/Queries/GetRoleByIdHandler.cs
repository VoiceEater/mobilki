using GameVault.Application.Roles.Queries;
using GameVault.Domain.Entities;
using GameVault.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameVault.Infrastructure.Roles.Queries;

public class GetRoleByIdHandler : IRequestHandler<GetRoleByIdQuery, Role?>
{
    private readonly AppDbContext _db;
    public GetRoleByIdHandler(AppDbContext db) => _db = db;

    public async Task<Role?> Handle(GetRoleByIdQuery request, CancellationToken ct)
    {
        return await _db.Roles.FirstOrDefaultAsync(r => r.Id == request.Id, ct);
    }
}
using GameVault.Application.Roles.Queries;
using GameVault.Domain.Entities;
using GameVault.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameVault.Infrastructure.Roles.Queries;

public class GetAllRolesHandler : IRequestHandler<GetAllRolesQuery, List<Role>>
{
    private readonly AppDbContext _db;
    public GetAllRolesHandler(AppDbContext db) => _db = db;

    public async Task<List<Role>> Handle(GetAllRolesQuery request, CancellationToken ct)
    {
        return await _db.Roles.ToListAsync(ct);
    }
}
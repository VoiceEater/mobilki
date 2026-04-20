using GameVault.Application.Users.Queries;
using GameVault.Domain.Entities;
using GameVault.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameVault.Infrastructure.Users.Queries;

public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, List<User>>
{
    private readonly AppDbContext _db;
    public GetAllUsersHandler(AppDbContext db) => _db = db;

    public async Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken ct)
    {
        return await _db.Users.Include(u => u.Role).ToListAsync(ct);
    }
}
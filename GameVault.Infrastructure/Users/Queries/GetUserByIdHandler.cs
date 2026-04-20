using GameVault.Application.Users.Queries;
using GameVault.Domain.Entities;
using GameVault.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameVault.Infrastructure.Users.Queries;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, User?>
{
    private readonly AppDbContext _db;
    public GetUserByIdHandler(AppDbContext db) => _db = db;

    public async Task<User?> Handle(GetUserByIdQuery request, CancellationToken ct)
    {
        return await _db.Users
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.Id == request.Id, ct);
    }
}
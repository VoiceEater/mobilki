using GameVault.Application.Users.Commands;
using GameVault.Domain.Entities;
using GameVault.Infrastructure.Data;
using MediatR;

namespace GameVault.Infrastructure.Users.Commands;

public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, User?>
{
    private readonly AppDbContext _db;
    public UpdateUserHandler(AppDbContext db) => _db = db;

    public async Task<User?> Handle(UpdateUserCommand request, CancellationToken ct)
    {
        var user = await _db.Users.FindAsync(new object[] { request.Id }, ct);
        if (user == null) return null;
        user.Username = request.Username;
        user.Email = request.Email;
        user.RoleId = request.RoleId;
        await _db.SaveChangesAsync(ct);
        return user;
    }
}
using GameVault.Application.Users.Commands;
using GameVault.Infrastructure.Data;
using MediatR;

namespace GameVault.Infrastructure.Users.Commands;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, bool>
{
    private readonly AppDbContext _db;
    public DeleteUserHandler(AppDbContext db) => _db = db;

    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken ct)
    {
        var user = await _db.Users.FindAsync(new object[] { request.Id }, ct);
        if (user == null) return false;
        _db.Users.Remove(user);
        await _db.SaveChangesAsync(ct);
        return true;
    }
}
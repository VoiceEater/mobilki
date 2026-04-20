using GameVault.Application.Users.Commands;
using GameVault.Domain.Entities;
using GameVault.Infrastructure.Data;
using MediatR;

namespace GameVault.Infrastructure.Users.Commands;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, User>
{
    private readonly AppDbContext _db;
    public CreateUserHandler(AppDbContext db) => _db = db;

    public async Task<User> Handle(CreateUserCommand request, CancellationToken ct)
    {
        var user = new User
        {
            Username = request.Username,
            Email = request.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            RoleId = request.RoleId
        };
        _db.Users.Add(user);
        await _db.SaveChangesAsync(ct);
        return user;
    }
}
using GameVault.Domain.Entities;
using MediatR;

namespace GameVault.Application.Users.Commands;

public record CreateUserCommand(string Username, string Email, string Password, int RoleId) : IRequest<User>;
using GameVault.Domain.Entities;
using MediatR;

namespace GameVault.Application.Users.Commands;

public record UpdateUserCommand(int Id, string Username, string Email, int RoleId) : IRequest<User?>;
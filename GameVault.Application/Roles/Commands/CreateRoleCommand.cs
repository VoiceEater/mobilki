using GameVault.Domain.Entities;
using MediatR;

namespace GameVault.Application.Roles.Commands;

public record CreateRoleCommand(string Name) : IRequest<Role>;
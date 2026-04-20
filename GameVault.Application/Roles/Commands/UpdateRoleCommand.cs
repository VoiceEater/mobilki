using GameVault.Domain.Entities;
using MediatR;

namespace GameVault.Application.Roles.Commands;

public record UpdateRoleCommand(int Id, string Name) : IRequest<Role?>;
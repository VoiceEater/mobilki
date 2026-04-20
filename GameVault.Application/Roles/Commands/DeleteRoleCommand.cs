using MediatR;

namespace GameVault.Application.Roles.Commands;

public record DeleteRoleCommand(int Id) : IRequest<bool>;
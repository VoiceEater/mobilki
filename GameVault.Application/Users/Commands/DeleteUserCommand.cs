using MediatR;

namespace GameVault.Application.Users.Commands;

public record DeleteUserCommand(int Id) : IRequest<bool>;
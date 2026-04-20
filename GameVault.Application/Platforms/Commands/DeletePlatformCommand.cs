using MediatR;

namespace GameVault.Application.Platforms.Commands;

public record DeletePlatformCommand(int Id) : IRequest<bool>;
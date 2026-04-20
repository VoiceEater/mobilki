using GameVault.Domain.Entities;
using MediatR;

namespace GameVault.Application.Platforms.Commands;

public record UpdatePlatformCommand(int Id, string Name) : IRequest<Platform?>;
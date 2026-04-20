using GameVault.Domain.Entities;
using MediatR;

namespace GameVault.Application.Platforms.Commands;

public record CreatePlatformCommand(string Name) : IRequest<Platform>;
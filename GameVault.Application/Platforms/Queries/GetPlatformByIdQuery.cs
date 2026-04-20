using GameVault.Domain.Entities;
using MediatR;

namespace GameVault.Application.Platforms.Queries;

public record GetPlatformByIdQuery(int Id) : IRequest<Platform?>;
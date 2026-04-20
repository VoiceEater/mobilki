using GameVault.Domain.Entities;
using MediatR;

namespace GameVault.Application.Platforms.Queries;

public record GetAllPlatformsQuery : IRequest<List<Platform>>;
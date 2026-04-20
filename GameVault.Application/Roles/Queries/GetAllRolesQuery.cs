using GameVault.Domain.Entities;
using MediatR;

namespace GameVault.Application.Roles.Queries;

public record GetAllRolesQuery : IRequest<List<Role>>;
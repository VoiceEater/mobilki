using GameVault.Domain.Entities;
using MediatR;

namespace GameVault.Application.Roles.Queries;

public record GetRoleByIdQuery(int Id) : IRequest<Role?>;
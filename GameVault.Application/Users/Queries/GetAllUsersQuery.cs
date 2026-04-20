using GameVault.Domain.Entities;
using MediatR;

namespace GameVault.Application.Users.Queries;

public record GetAllUsersQuery : IRequest<List<User>>;
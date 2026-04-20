using GameVault.Domain.Entities;
using MediatR;

namespace GameVault.Application.Users.Queries;

public record GetUserByIdQuery(int Id) : IRequest<User?>;
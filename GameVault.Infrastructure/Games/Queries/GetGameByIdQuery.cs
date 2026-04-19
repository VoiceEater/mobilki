using GameVault.Domain.Entities;
using MediatR;

namespace GameVault.Application.Games.Queries;

public record GetGameByIdQuery(int Id) : IRequest<Game?>;
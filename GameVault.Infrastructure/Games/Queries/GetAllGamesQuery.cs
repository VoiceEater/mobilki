using GameVault.Domain.Entities;
using MediatR;

namespace GameVault.Application.Games.Queries;

public record GetAllGamesQuery : IRequest<List<Game>>;
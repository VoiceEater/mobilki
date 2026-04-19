using GameVault.Domain.Entities;
using MediatR;

namespace GameVault.Application.Games.Commands;

public record CreateGameCommand(
    string Title,
    string Description,
    decimal Price,
    DateTime ReleaseDate,
    string ImageUrl,
    int PublisherId,
    List<int> GenreIds,
    List<int> PlatformIds
) : IRequest<Game>;
using MediatR;

namespace GameVault.Application.Genres.Commands;

public record DeleteGenreCommand(int Id) : IRequest<bool>;
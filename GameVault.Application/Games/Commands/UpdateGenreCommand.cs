using GameVault.Domain.Entities;
using MediatR;

namespace GameVault.Application.Genres.Commands;

public record UpdateGenreCommand(int Id, string Name) : IRequest<Genre?>;
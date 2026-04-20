using GameVault.Domain.Entities;
using MediatR;

namespace GameVault.Application.Genres.Commands;

public record CreateGenreCommand(string Name) : IRequest<Genre>;
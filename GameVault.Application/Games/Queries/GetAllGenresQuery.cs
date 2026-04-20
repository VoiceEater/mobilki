using GameVault.Domain.Entities;
using MediatR;

namespace GameVault.Application.Genres.Queries;

public record GetAllGenresQuery : IRequest<List<Genre>>;
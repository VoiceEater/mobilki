using GameVault.Domain.Entities;
using MediatR;

namespace GameVault.Application.Genres.Queries;

public record GetGenreByIdQuery(int Id) : IRequest<Genre?>;
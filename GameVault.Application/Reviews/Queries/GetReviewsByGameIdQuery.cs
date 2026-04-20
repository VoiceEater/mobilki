using GameVault.Domain.Entities;
using MediatR;

namespace GameVault.Application.Reviews.Queries;

public record GetReviewsByGameIdQuery(int GameId) : IRequest<List<Review>>;
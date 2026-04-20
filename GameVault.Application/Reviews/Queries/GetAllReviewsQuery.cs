using GameVault.Domain.Entities;
using MediatR;

namespace GameVault.Application.Reviews.Queries;

public record GetAllReviewsQuery : IRequest<List<Review>>;
using GameVault.Domain.Entities;
using MediatR;

namespace GameVault.Application.Reviews.Commands;

public record CreateReviewCommand(int GameId, int UserId, int Rating, string Content) : IRequest<Review>;
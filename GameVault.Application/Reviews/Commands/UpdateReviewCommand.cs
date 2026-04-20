using GameVault.Domain.Entities;
using MediatR;

namespace GameVault.Application.Reviews.Commands;

public record UpdateReviewCommand(int Id, int Rating, string Content) : IRequest<Review?>;
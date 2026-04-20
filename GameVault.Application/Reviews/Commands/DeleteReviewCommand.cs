using MediatR;

namespace GameVault.Application.Reviews.Commands;

public record DeleteReviewCommand(int Id) : IRequest<bool>;
using GameVault.Application.Reviews.Commands;
using GameVault.Domain.Entities;
using GameVault.Infrastructure.Data;
using MediatR;

namespace GameVault.Infrastructure.Reviews.Commands;

public class CreateReviewHandler : IRequestHandler<CreateReviewCommand, Review>
{
    private readonly AppDbContext _db;
    public CreateReviewHandler(AppDbContext db) => _db = db;

    public async Task<Review> Handle(CreateReviewCommand request, CancellationToken ct)
    {
        var review = new Review
        {
            GameId = request.GameId,
            UserId = request.UserId,
            Rating = request.Rating,
            Content = request.Content,
            CreatedAt = DateTime.UtcNow
        };
        _db.Reviews.Add(review);
        await _db.SaveChangesAsync(ct);
        return review;
    }
}

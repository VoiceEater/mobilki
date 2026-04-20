using GameVault.Application.Reviews.Commands;
using GameVault.Domain.Entities;
using GameVault.Infrastructure.Data;
using MediatR;

namespace GameVault.Infrastructure.Reviews.Commands;

public class UpdateReviewHandler : IRequestHandler<UpdateReviewCommand, Review?>
{
    private readonly AppDbContext _db;
    public UpdateReviewHandler(AppDbContext db) => _db = db;

    public async Task<Review?> Handle(UpdateReviewCommand request, CancellationToken ct)
    {
        var review = await _db.Reviews.FindAsync(new object[] { request.Id }, ct);
        if (review == null) return null;
        review.Rating = request.Rating;
        review.Content = request.Content;
        await _db.SaveChangesAsync(ct);
        return review;
    }
}
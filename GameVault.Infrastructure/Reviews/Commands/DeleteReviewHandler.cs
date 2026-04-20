using GameVault.Application.Reviews.Commands;
using GameVault.Infrastructure.Data;
using MediatR;

namespace GameVault.Infrastructure.Reviews.Commands;

public class DeleteReviewHandler : IRequestHandler<DeleteReviewCommand, bool>
{
    private readonly AppDbContext _db;
    public DeleteReviewHandler(AppDbContext db) => _db = db;

    public async Task<bool> Handle(DeleteReviewCommand request, CancellationToken ct)
    {
        var review = await _db.Reviews.FindAsync(new object[] { request.Id }, ct);
        if (review == null) return false;
        _db.Reviews.Remove(review);
        await _db.SaveChangesAsync(ct);
        return true;
    }
}
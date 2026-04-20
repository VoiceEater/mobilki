using GameVault.Application.Reviews.Queries;
using GameVault.Domain.Entities;
using GameVault.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameVault.Infrastructure.Reviews.Queries;

public class GetAllReviewsHandler : IRequestHandler<GetAllReviewsQuery, List<Review>>
{
    private readonly AppDbContext _db;
    public GetAllReviewsHandler(AppDbContext db) => _db = db;

    public async Task<List<Review>> Handle(GetAllReviewsQuery request, CancellationToken ct)
    {
        return await _db.Reviews
            .Include(r => r.User)
            .Include(r => r.Game)
            .ToListAsync(ct);
    }
}
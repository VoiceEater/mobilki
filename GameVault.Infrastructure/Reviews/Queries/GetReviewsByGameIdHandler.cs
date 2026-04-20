using GameVault.Application.Reviews.Queries;
using GameVault.Domain.Entities;
using GameVault.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameVault.Infrastructure.Reviews.Queries;

public class GetReviewsByGameIdHandler : IRequestHandler<GetReviewsByGameIdQuery, List<Review>>
{
    private readonly AppDbContext _db;
    public GetReviewsByGameIdHandler(AppDbContext db) => _db = db;

    public async Task<List<Review>> Handle(GetReviewsByGameIdQuery request, CancellationToken ct)
    {
        return await _db.Reviews
            .Where(r => r.GameId == request.GameId)
            .Include(r => r.User)
            .ToListAsync(ct);
    }
}
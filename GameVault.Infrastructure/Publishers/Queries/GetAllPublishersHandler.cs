using GameVault.Application.Publishers.Queries;
using GameVault.Domain.Entities;
using GameVault.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameVault.Infrastructure.Publishers.Queries;

public class GetAllPublishersHandler : IRequestHandler<GetAllPublishersQuery, List<Publisher>>
{
    private readonly AppDbContext _db;
    public GetAllPublishersHandler(AppDbContext db) => _db = db;

    public async Task<List<Publisher>> Handle(GetAllPublishersQuery request, CancellationToken ct)
    {
        return await _db.Publishers.ToListAsync(ct);
    }
}
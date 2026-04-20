using GameVault.Application.Publishers.Queries;
using GameVault.Domain.Entities;
using GameVault.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameVault.Infrastructure.Publishers.Queries;

public class GetPublisherByIdHandler : IRequestHandler<GetPublisherByIdQuery, Publisher?>
{
    private readonly AppDbContext _db;
    public GetPublisherByIdHandler(AppDbContext db) => _db = db;

    public async Task<Publisher?> Handle(GetPublisherByIdQuery request, CancellationToken ct)
    {
        return await _db.Publishers
            .Include(p => p.Games)
            .FirstOrDefaultAsync(p => p.Id == request.Id, ct);
    }
}
using GameVault.Application.Publishers.Commands;
using GameVault.Domain.Entities;
using GameVault.Infrastructure.Data;
using MediatR;

namespace GameVault.Infrastructure.Publishers.Commands;

public class UpdatePublisherHandler : IRequestHandler<UpdatePublisherCommand, Publisher?>
{
    private readonly AppDbContext _db;
    public UpdatePublisherHandler(AppDbContext db) => _db = db;

    public async Task<Publisher?> Handle(UpdatePublisherCommand request, CancellationToken ct)
    {
        var publisher = await _db.Publishers.FindAsync(new object[] { request.Id }, ct);
        if (publisher == null) return null;
        publisher.Name = request.Name;
        publisher.Country = request.Country;
        await _db.SaveChangesAsync(ct);
        return publisher;
    }
}
using GameVault.Application.Publishers.Commands;
using GameVault.Infrastructure.Data;
using MediatR;

namespace GameVault.Infrastructure.Publishers.Commands;

public class DeletePublisherHandler : IRequestHandler<DeletePublisherCommand, bool>
{
    private readonly AppDbContext _db;
    public DeletePublisherHandler(AppDbContext db) => _db = db;

    public async Task<bool> Handle(DeletePublisherCommand request, CancellationToken ct)
    {
        var publisher = await _db.Publishers.FindAsync(new object[] { request.Id }, ct);
        if (publisher == null) return false;
        _db.Publishers.Remove(publisher);
        await _db.SaveChangesAsync(ct);
        return true;
    }
}
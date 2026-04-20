using GameVault.Application.Publishers.Commands;
using GameVault.Domain.Entities;
using GameVault.Infrastructure.Data;
using MediatR;

namespace GameVault.Infrastructure.Publishers.Commands;

public class CreatePublisherHandler : IRequestHandler<CreatePublisherCommand, Publisher>
{
    private readonly AppDbContext _db;
    public CreatePublisherHandler(AppDbContext db) => _db = db;

    public async Task<Publisher> Handle(CreatePublisherCommand request, CancellationToken ct)
    {
        var publisher = new Publisher { Name = request.Name, Country = request.Country };
        _db.Publishers.Add(publisher);
        await _db.SaveChangesAsync(ct);
        return publisher;
    }
}
using GameVault.Domain.Entities;
using MediatR;

namespace GameVault.Application.Publishers.Queries;

public record GetAllPublishersQuery : IRequest<List<Publisher>>;
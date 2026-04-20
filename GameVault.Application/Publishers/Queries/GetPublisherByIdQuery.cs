using GameVault.Domain.Entities;
using MediatR;

namespace GameVault.Application.Publishers.Queries;

public record GetPublisherByIdQuery(int Id) : IRequest<Publisher?>;
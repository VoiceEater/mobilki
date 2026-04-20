using GameVault.Domain.Entities;
using MediatR;

namespace GameVault.Application.Publishers.Commands;

public record UpdatePublisherCommand(int Id, string Name, string Country) : IRequest<Publisher?>;
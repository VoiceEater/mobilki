using GameVault.Domain.Entities;
using MediatR;

namespace GameVault.Application.Publishers.Commands;

public record CreatePublisherCommand(string Name, string Country) : IRequest<Publisher>;
using MediatR;

namespace GameVault.Application.Publishers.Commands;

public record DeletePublisherCommand(int Id) : IRequest<bool>;
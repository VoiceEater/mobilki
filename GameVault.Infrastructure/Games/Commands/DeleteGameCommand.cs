using MediatR;

namespace GameVault.Application.Games.Commands;

public record DeleteGameCommand(int Id) : IRequest<bool>;
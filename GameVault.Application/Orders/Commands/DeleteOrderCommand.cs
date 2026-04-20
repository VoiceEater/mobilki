using MediatR;

namespace GameVault.Application.Orders.Commands;

public record DeleteOrderCommand(int Id) : IRequest<bool>;
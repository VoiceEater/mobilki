using GameVault.Domain.Entities;
using MediatR;

namespace GameVault.Application.Orders.Commands;

public record CreateOrderItemDto(int GameId, int Quantity, decimal UnitPrice);
public record CreateOrderCommand(int UserId, List<CreateOrderItemDto> Items) : IRequest<Order>;
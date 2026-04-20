using GameVault.Domain.Entities;
using MediatR;

namespace GameVault.Application.Orders.Queries;

public record GetOrdersByUserIdQuery(int UserId) : IRequest<List<Order>>;
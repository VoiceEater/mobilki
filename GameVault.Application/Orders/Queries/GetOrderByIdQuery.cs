using GameVault.Domain.Entities;
using MediatR;

namespace GameVault.Application.Orders.Queries;

public record GetOrderByIdQuery(int Id) : IRequest<Order?>;
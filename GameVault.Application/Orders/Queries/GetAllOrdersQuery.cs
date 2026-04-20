using GameVault.Domain.Entities;
using MediatR;

namespace GameVault.Application.Orders.Queries;

public record GetAllOrdersQuery : IRequest<List<Order>>;
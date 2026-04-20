using GameVault.Domain.Entities;
using MediatR;

namespace GameVault.Application.Wishlists.Queries;

public record GetWishlistByUserIdQuery(int UserId) : IRequest<List<WishlistItem>>;
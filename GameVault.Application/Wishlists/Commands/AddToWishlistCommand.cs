using GameVault.Domain.Entities;
using MediatR;

namespace GameVault.Application.Wishlists.Commands;

public record AddToWishlistCommand(int UserId, int GameId) : IRequest<WishlistItem>;
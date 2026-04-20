using MediatR;

namespace GameVault.Application.Wishlists.Commands;

public record RemoveFromWishlistCommand(int Id) : IRequest<bool>;
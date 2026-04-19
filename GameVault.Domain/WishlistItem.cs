namespace GameVault.Domain.Entities;

public class WishlistItem
{
    public int Id { get; set; }
    public DateTime AddedAt { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public int GameId { get; set; }
    public Game Game { get; set; } = null!;
}
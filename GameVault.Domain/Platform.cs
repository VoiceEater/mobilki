namespace GameVault.Domain.Entities;

public class Platform
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<GamePlatform> GamePlatforms { get; set; } = new List<GamePlatform>();
}
namespace GameVault.Domain.Entities;

public class Publisher
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public ICollection<Game> Games { get; set; } = new List<Game>();
}
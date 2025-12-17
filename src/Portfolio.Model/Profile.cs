namespace Portfolio.Model;

public class Profile
{
    public int Id { get; set; }
    public string? FullName { get; set; }
    public string? Title { get; set; }
    public string? Summary { get; set; }
    public string? Location { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

namespace Library.Domain;

public class RefreshToken
{
    public int Id { get; set; }
    public string Token { get; set; }
    public DateTimeOffset ExpiresAt { get; set; }
    public bool IsRevoked { get; set; }
    public string UserId { get; set; }
}
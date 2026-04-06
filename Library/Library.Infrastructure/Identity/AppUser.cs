using Microsoft.AspNetCore.Identity;

namespace Library.Domain;

public class AppUser :IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Address { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime Birthday { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public ICollection<UserBook> UserBooks { get; set; } = new List<UserBook>();
    public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
}

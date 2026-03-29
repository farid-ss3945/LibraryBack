using Library.Domain;

namespace Library.Application.DTOs.User;

public class UserResponseDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Address { get; set; }
    public string PhoneNumber { get; set; }
    public DateTimeOffset Birthday { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public ICollection<UserBook> UserBooks { get; set; } = new List<UserBook>();
}
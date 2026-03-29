namespace Library.Domain;
public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string AuthorName { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public ICollection<UserBook> UserBooks { get; set; } = new List<UserBook>();
}
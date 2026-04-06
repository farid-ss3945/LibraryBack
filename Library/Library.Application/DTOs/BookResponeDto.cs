namespace Library.Application.DTOs;

public class BookResponeDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string AuthorName { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}
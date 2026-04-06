using Library.Domain;

namespace Library.Application.Interfaces;

public interface IBookRepo
{
    Task<Book> AddAsync(Book book);
    Task<IEnumerable<Book>?> GetAllBooksAsync();
    Task<bool> DeleteBookAsync(int id);
    Task AddBookToLibraryAsync(string userId, int bookId);
    Task RemoveBookFromLibraryAsync(string userId, int bookId);
}
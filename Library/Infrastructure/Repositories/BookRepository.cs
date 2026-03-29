using Library.Application.Interfaces;
using Library.Domain;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class BookRepository : IBookRepo
{
    private readonly OnlineLibDbContext _context;

    public BookRepository(OnlineLibDbContext context)
    {
        _context = context;
    }
    public async Task<Book> AddAsync(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return book;
    }

    public async Task<IEnumerable<Book>?> GetAllBooksAsync()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task<bool> DeleteBookAsync(int id)
    {
        var book = await _context.Books.FirstOrDefaultAsync(c => c.Id == id);
        if (book == null)
        {
            return false;
        }
        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
        return true;
    }
    
    public async Task AddBookToLibraryAsync(string userId, int bookId)
    {
        var userBook = new UserBook
        {
            UserId = userId,
            BookId = bookId
        };
        await _context.UserBooks.AddAsync(userBook);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveBookFromLibraryAsync(string userId, int bookId)
    {
        var userBook = await _context.UserBooks
            .FirstOrDefaultAsync(ub => ub.UserId == userId && ub.BookId == bookId);

        if (userBook is null) return;

        _context.UserBooks.Remove(userBook);
        await _context.SaveChangesAsync();
    }
}
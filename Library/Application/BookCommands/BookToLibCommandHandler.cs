using Library.Application.Interfaces;
using Library.Domain;
using MediatR;

namespace Library.Application.BookCommands;

public class BookToLibCommandHandler:IRequestHandler<BookToLibCommand,Unit>
{
    private readonly IBookRepo _bookRepository;

    public BookToLibCommandHandler(IBookRepo bookRepository)
    {
        _bookRepository = bookRepository;
    }
    
    public async Task<Unit> Handle(BookToLibCommand request, CancellationToken cancellationToken)
    {
        await _bookRepository.AddBookToLibraryAsync(request.userId,request.bookId);
        return Unit.Value;
    }
}
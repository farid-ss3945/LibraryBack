using Library.Application.Interfaces;
using Library.Domain;
using MediatR;

namespace Library.Application.BookCommands;

public class BookFromLibCommandHandler:IRequestHandler<BookFromLibCommand,Unit>
{
    private readonly IBookRepo _bookRepository;

    public BookFromLibCommandHandler(IBookRepo bookRepository)
    {
        _bookRepository = bookRepository;
    }
    
    public async Task<Unit> Handle(BookFromLibCommand request, CancellationToken cancellationToken)
    {
        await _bookRepository.RemoveBookFromLibraryAsync(request.userId,request.bookId);
        return Unit.Value;
    }
}
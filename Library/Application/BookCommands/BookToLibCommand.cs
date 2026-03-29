using MediatR;

namespace Library.Application.BookCommands;

public record BookToLibCommand(string userId, int bookId):IRequest<Unit>;
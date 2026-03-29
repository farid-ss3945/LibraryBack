using MediatR;

namespace Library.Application.BookCommands;

public record BookFromLibCommand(string userId, int bookId):IRequest<Unit>;
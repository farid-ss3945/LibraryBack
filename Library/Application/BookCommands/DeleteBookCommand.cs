using MediatR;

namespace Library.Application.BookCommands;

public record DeleteBookCommand(int id):IRequest<bool>;
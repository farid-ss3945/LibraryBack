using Library.Application.DTOs;
using MediatR;

namespace Library.Application.BookCommands;

public record AddBookCommand(CreateBookDto dto):IRequest<BookResponeDto>;
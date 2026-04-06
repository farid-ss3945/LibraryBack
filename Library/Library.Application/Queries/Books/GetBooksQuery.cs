using Library.Application.DTOs;
using MediatR;

namespace Library.Application.Queries.Books;

public record GetBooksQuery():IRequest<IEnumerable<BookResponeDto>>;
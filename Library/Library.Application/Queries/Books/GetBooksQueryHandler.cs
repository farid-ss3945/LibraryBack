using AutoMapper;
using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Application.Queries.Books;
using MediatR;

namespace Library.Application.Queries.Books;

public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery,IEnumerable<BookResponeDto>>
{
    private readonly IBookRepo _bookRepository;
    private readonly IMapper _mapper;

    public GetBooksQueryHandler(IBookRepo bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<BookResponeDto>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await _bookRepository.GetAllBooksAsync();
        return _mapper.Map<IEnumerable<BookResponeDto>>(books);
    }
}
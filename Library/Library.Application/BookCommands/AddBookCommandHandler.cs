using AutoMapper;
using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Domain;
using MediatR;

namespace Library.Application.BookCommands;

public class AddBookCommandHandler:IRequestHandler<AddBookCommand,BookResponeDto>
{
    private readonly IBookRepo _bookRepository;
    private readonly IMapper _mapper;

    public AddBookCommandHandler(IBookRepo bookRepository,IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }
    public async Task<BookResponeDto> Handle(AddBookCommand request, CancellationToken cancellationToken)
    {
        var book = _mapper.Map<Book>(request.dto);
        await _bookRepository.AddAsync(book);
        return _mapper.Map<BookResponeDto>(book);
    }
}
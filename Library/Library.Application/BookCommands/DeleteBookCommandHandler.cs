using AutoMapper;
using Library.Application.Interfaces;
using MediatR;

namespace Library.Application.BookCommands;

public class DeleteBookCommandHandler:IRequestHandler<DeleteBookCommand,bool>
{
    private readonly IBookRepo _bookRepository;
    private readonly IMapper _mapper;

    public DeleteBookCommandHandler(IBookRepo bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }
    
    public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        return await _bookRepository.DeleteBookAsync(request.id);
    }
}
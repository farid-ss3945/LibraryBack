using Library.Application.DTOs.User;
using Library.Application.Interfaces;
using MediatR;

namespace Library.Infrastructure.UserQueries;

public class GetAllUsersQueryHandler:IRequestHandler<GetAllUsersQuery,IEnumerable<UserResponseDto>?>
{
    private readonly IUserRepo _userRepository;

    public GetAllUsersQueryHandler(IUserRepo userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<IEnumerable<UserResponseDto>?> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        return await _userRepository.GetAllAsync();
    }
}
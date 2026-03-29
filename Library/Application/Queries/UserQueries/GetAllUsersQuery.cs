using Library.Application.DTOs.User;
using MediatR;

namespace Library.Infrastructure.UserQueries;

public record GetAllUsersQuery():IRequest<IEnumerable<UserResponseDto>?>;
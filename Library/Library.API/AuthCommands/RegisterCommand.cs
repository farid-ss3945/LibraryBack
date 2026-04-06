using Library.Application.DTOs;
using MediatR;

namespace Library.API.AuthCommands;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string Address,
    string PhoneNumber,
    DateTime Birthday
) : IRequest<AuthResponseDto>;
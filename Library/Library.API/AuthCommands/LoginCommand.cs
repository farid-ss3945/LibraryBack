using Library.Application.DTOs;
using MediatR;

namespace Library.API.AuthCommands;

public record LoginCommand(
    string Email,
    string Password
) : IRequest<AuthResponseDto>;
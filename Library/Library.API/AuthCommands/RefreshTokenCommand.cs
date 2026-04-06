using Library.Application.DTOs;
using MediatR;

namespace Library.API.AuthCommands;

public class RefreshTokenCommand : IRequest<AuthResponseDto>
{
    public string RefreshToken { get; set; }
}
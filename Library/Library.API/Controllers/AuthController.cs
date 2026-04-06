using Library.API.AuthCommands;
using Library.Application.BookCommands;
using Library.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Controllers;

[Route("api/[controller]")]
[ApiController]

public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly OnlineLibDbContext _context;
    public AuthController(IMediator mediator,OnlineLibDbContext context)
    {
        _mediator = mediator;
        _context = context;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
    
    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] RefreshTokenCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
}
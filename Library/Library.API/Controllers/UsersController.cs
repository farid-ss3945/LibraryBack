using Library.Infrastructure.UserQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

[Route("api/[controller]")]
[ApiController]

public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;
    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("Users/GetAll")]
    [Authorize(Policy = "LibrarianOrAbove")]
    public async Task<IActionResult> GetUsers()
    {
        return Ok(await _mediator.Send(new GetAllUsersQuery()));
    }
}
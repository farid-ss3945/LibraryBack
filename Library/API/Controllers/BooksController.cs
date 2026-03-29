using System.Security.Claims;
using Library.Application.BookCommands;
using Library.Application.Queries.Books;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Library.API.Controllers;

[Route("api/[controller]")]
[ApiController]

public class BooksController : ControllerBase
{
    private readonly IMediator _mediator;
    public BooksController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("Books/AddToLibrary")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> AddToLibrary(AddBookCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpGet("Books/GetAll")]
    public async Task<IActionResult> GetBooks()
    {
        return Ok(await _mediator.Send(new GetBooksQuery()));
    }

    [HttpDelete("Books/Delete")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> DeleteBook(DeleteBookCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
    
    [HttpPost("{bookId}/add")]
    [Authorize]
    public async Task<IActionResult> AddBook(int bookId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        await _mediator.Send(new BookToLibCommand(userId, bookId));
        return Ok();
    }
    
    [HttpPost("{bookId}/remove")]
    [Authorize]
    public async Task<IActionResult> RemoveBook(int bookId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        await _mediator.Send(new BookFromLibCommand(userId, bookId));
        return Ok();
    }
}
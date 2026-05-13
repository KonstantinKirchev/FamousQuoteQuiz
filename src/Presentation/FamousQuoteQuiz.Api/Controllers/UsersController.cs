using FamousQuoteQuiz.Application.Features.User.Commands.DeleteUser;
using FamousQuoteQuiz.Application.Features.User.Commands.UpdateUser;
using FamousQuoteQuiz.Application.Features.User.Queries.GetUsers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FamousQuoteQuiz.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/<UsersController>
    [HttpGet]
    public async Task<ActionResult<List<GetUserDto>>> Get(bool isLoggedInUser = false)
    {
        var users = await _mediator.Send(new GetUsersQuery());
        return Ok(users);
    }


    // PUT api/<UsersController>/5
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Put(UpdateUserCommand quote)
    {
        await _mediator.Send(quote);
        return NoContent();
    }

    // DELETE api/<UsersController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteUserCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }
}

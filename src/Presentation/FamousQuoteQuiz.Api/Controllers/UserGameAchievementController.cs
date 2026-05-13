using FamousQuoteQuiz.Application.Features.UserGameAchievement.Commands.CreateUserGameAchievement;
using FamousQuoteQuiz.Application.Features.UserGameAchievement.Queries.GetUserGameAchievements;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FamousQuoteQuiz.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserGameAchievementController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserGameAchievementController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/<UserGameAchievementController>
    [HttpGet]
    public async Task<ActionResult<List<UserGameAchievementDto>>> Get()
    {
        var achievements = await _mediator.Send(new GetUserGameAchievementsQuery());
        return Ok(achievements);
    }

    // POST api/<UserGameAchievementController>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Post(CreateUserGameAchievementCommand quoteRequest)
    {
        var response = await _mediator.Send(quoteRequest);
        return CreatedAtAction(nameof(Get), new { id = response });
    }
}

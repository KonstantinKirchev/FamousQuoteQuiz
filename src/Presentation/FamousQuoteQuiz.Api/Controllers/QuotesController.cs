using FamousQuoteQuiz.Application.Features.Quote.Commands.CreateQuote;
using FamousQuoteQuiz.Application.Features.Quote.Commands.DeleteQuote;
using FamousQuoteQuiz.Application.Features.Quote.Commands.UpdateQuote;
using FamousQuoteQuiz.Application.Features.Quote.Queries.GetQuotes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FamousQuoteQuiz.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class QuotesController : ControllerBase
{
    private readonly IMediator _mediator;

    public QuotesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/<QuotesController>
    [HttpGet]
    public async Task<ActionResult<List<QuoteDto>>> Get(bool isLoggedInUser = false)
    {
        var quotes = await _mediator.Send(new GetQuotesQuery());
        return Ok(quotes);
    }

    // POST api/<QuotesController>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Post(CreateQuoteCommand quoteRequest)
    {
        var response = await _mediator.Send(quoteRequest);
        return CreatedAtAction(nameof(Get), new { id = response });
    }

    // PUT api/<QuotesController>/5
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Put(UpdateQuoteCommand quote)
    {
        await _mediator.Send(quote);
        return NoContent();
    }

    // DELETE api/<QuotesController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteQuoteCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}

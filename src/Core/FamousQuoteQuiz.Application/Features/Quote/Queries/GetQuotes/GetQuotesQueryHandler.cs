using AutoMapper;
using FamousQuoteQuiz.Application.Contracts.Identity;
using FamousQuoteQuiz.Application.Contracts.Persistence;
using MediatR;

namespace FamousQuoteQuiz.Application.Features.Quote.Queries.GetQuotes;

public class GetQuotesQueryHandler : IRequestHandler<GetQuotesQuery, List<QuoteDto>>
{
    private readonly IQuoteRepository _quoteRepository;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public GetQuotesQueryHandler(IQuoteRepository quoteRepository,
        IMapper mapper, IUserService userService)
    {
        _quoteRepository = quoteRepository;
        _mapper = mapper;
        _userService = userService;
    }

    public async Task<List<QuoteDto>> Handle(GetQuotesQuery request, CancellationToken cancellationToken)
    {

        var quotes = new List<Domain.Entities.Quote>();
        var requests = new List<QuoteDto>();

        // Check if it is logged in employee
        //if (request.IsLoggedInUser)
        //{
        //    var userId = _userService.UserId;
        //    quotes = await _quoteRepository.GetQuoteDetails(userId);

        //    var user = await _userService.GetUser(userId);
        //    requests = _mapper.Map<List<QuoteDto>>(quotes);
        //}
        //else
        //{
            quotes = await _quoteRepository.GetQuotesWithDetails();
            requests = _mapper.Map<List<QuoteDto>>(quotes);
        //}

        return requests;
    }
}

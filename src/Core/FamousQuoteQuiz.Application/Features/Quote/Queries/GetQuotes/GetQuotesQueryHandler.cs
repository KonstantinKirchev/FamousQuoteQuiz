using AutoMapper;
using FamousQuoteQuiz.Application.Contracts.Persistence;
using MediatR;

namespace FamousQuoteQuiz.Application.Features.Quote.Queries.GetQuotes;

public class GetQuotesQueryHandler : IRequestHandler<GetQuotesQuery, List<QuoteDto>>
{
    private readonly IQuoteRepository _quoteRepository;
    private readonly IMapper _mapper;

    public GetQuotesQueryHandler(IQuoteRepository quoteRepository,
        IMapper mapper)
    {
        _quoteRepository = quoteRepository;
        _mapper = mapper;
    }

    public async Task<List<QuoteDto>> Handle(GetQuotesQuery request, CancellationToken cancellationToken)
    {
        var quotes = new List<Domain.Entities.Quote>();
        var requests = new List<QuoteDto>();
       
        quotes = (List<Domain.Entities.Quote>)await _quoteRepository.GetAllQuotesAsync();
        requests = _mapper.Map<List<QuoteDto>>(quotes);
       
        return requests;
    }
}

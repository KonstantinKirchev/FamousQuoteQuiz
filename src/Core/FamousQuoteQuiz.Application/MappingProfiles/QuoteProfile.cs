using AutoMapper;
using FamousQuoteQuiz.Application.Features.Quote.Commands.CreateQuote;
using FamousQuoteQuiz.Application.Features.Quote.Queries.GetQuotes;
using FamousQuoteQuiz.Domain.Entities;

namespace FamousQuoteQuiz.Application.MappingProfiles;

public class QuoteProfile : Profile
{
    public QuoteProfile()
    {
        CreateMap<QuoteDto, Quote>().ReverseMap();
        CreateMap<CreateQuoteCommand, Quote>();
    }
}

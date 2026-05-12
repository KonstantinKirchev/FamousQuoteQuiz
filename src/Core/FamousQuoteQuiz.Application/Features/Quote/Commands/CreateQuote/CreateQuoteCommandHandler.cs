using AutoMapper;
using FamousQuoteQuiz.Application.Contracts.Persistence;
using FamousQuoteQuiz.Application.Exceptions;
using MediatR;

namespace FamousQuoteQuiz.Application.Features.Quote.Commands.CreateQuote;

public class CreateQuoteCommandHandler : IRequestHandler<CreateQuoteCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IQuoteRepository _quoteRepository;

    public CreateQuoteCommandHandler(IMapper mapper, IQuoteRepository quoteRepository)
    {
        _mapper = mapper;
        _quoteRepository = quoteRepository;
    }

    public async Task<Unit> Handle(CreateQuoteCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateQuoteCommandValidator(_quoteRepository);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid Quote Request", validationResult);

        var quote = _mapper.Map<Domain.Entities.Quote>(request);
        await _quoteRepository.CreateAsync(quote);

        return Unit.Value;
    }
}

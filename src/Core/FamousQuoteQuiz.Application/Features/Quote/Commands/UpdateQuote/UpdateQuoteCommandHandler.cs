using AutoMapper;
using FamousQuoteQuiz.Application.Contracts.Persistence;
using FamousQuoteQuiz.Application.Exceptions;
using MediatR;

namespace FamousQuoteQuiz.Application.Features.Quote.Commands.UpdateQuote;

public class UpdateQuoteCommandHandler : IRequestHandler<UpdateQuoteCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IQuoteRepository _quoteRepository;

    public UpdateQuoteCommandHandler(IQuoteRepository quoteRepository, IMapper mapper)
    {
        _quoteRepository = quoteRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateQuoteCommand request, CancellationToken cancellationToken)
    {
        var quote = await _quoteRepository.GetByIdAsync(request.Id);

        if (quote is null)
            throw new NotFoundException(nameof(Quote), request.Id);


        var validator = new UpdateQuoteCommandValidator(_quoteRepository);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid quote", validationResult);

        _mapper.Map(request, quote);

        await _quoteRepository.UpdateAsync(quote);

        return Unit.Value;
    }
}

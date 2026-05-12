using AutoMapper;
using FamousQuoteQuiz.Application.Exceptions;
using FamousQuoteQuiz.Domain.Interfaces;
using MediatR;

namespace FamousQuoteQuiz.Application.Features.User.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Unit>
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IUserRepository repository, IMapper mapper) { 
        _repository = repository; 
        _mapper = mapper;
    }

    public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateUserCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid User Request", validationResult);

        var user = _mapper.Map<Domain.Entities.User>(request);
        await _repository.CreateUserAsync(user);
        await _repository.SaveChangesAsync();
        return Unit.Value;
    }
}

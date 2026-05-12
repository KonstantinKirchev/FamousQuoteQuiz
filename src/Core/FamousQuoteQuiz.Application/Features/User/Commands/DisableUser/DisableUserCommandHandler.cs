using FamousQuoteQuiz.Application.Exceptions;
using FamousQuoteQuiz.Domain.Interfaces;
using MediatR;

namespace FamousQuoteQuiz.Application.Features.User.Commands.DisableUser;

public class DisableUserCommandHandler : IRequestHandler<DisableUserCommand, Unit>
{
    private readonly IUserRepository _repository;
    public DisableUserCommandHandler(IUserRepository repository) => _repository = repository;

    public async Task<Unit> Handle(DisableUserCommand request, CancellationToken cancellationToken)
    {
        var validator = new DisableUserCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid User Request", validationResult);

        var user = await _repository.GetByIdAsync(request.Id);
        if (user != null)
        {
            user.IsActive = false; // Business logic for 'disable'
            await _repository.UpdateAsync(user);
            await _repository.SaveChangesAsync();
        }
        return Unit.Value;
    }
}

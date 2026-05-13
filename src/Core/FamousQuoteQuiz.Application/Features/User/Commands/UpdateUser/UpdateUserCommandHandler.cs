using FamousQuoteQuiz.Application.Exceptions;
using FamousQuoteQuiz.Domain.Interfaces;
using MediatR;

namespace FamousQuoteQuiz.Application.Features.User.Commands.UpdateUser;

public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, Unit>
{
    private readonly IUserRepository _repository;
    public UpdateUserHandler(IUserRepository repository) => _repository = repository;

    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateUserCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid User Request", validationResult);

        var user = await _repository.GetByIdAsync(request.Id);
        if (user == null) 
            throw new KeyNotFoundException($"User with ID {request.Id} not found.");

        user.UserName = request.UserName;
        user.Email = request.Email;
        user.IsActive = request.IsActive;

        await _repository.UpdateAsync(user);
        await _repository.SaveChangesAsync();

        return Unit.Value;
    }
}

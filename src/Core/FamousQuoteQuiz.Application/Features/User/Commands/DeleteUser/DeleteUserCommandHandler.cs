using FamousQuoteQuiz.Application.Exceptions;
using FamousQuoteQuiz.Domain.Interfaces;
using MediatR;

namespace FamousQuoteQuiz.Application.Features.User.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
{
    private readonly IUserRepository _repository;
    public DeleteUserCommandHandler(IUserRepository repository) => _repository = repository;

    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteUserCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid User Request", validationResult);

        var user = await _repository.GetByIdAsync(request.Id);
        await _repository.DisableUserAsync(user);
        await _repository.SaveChangesAsync();
        return Unit.Value;
    }
}

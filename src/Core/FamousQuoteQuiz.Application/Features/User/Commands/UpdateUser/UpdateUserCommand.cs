using MediatR;

namespace FamousQuoteQuiz.Application.Features.User.Commands.UpdateUser;

public record UpdateUserCommand(int Id, string UserName, string Email, bool IsActive) : IRequest<Unit>;

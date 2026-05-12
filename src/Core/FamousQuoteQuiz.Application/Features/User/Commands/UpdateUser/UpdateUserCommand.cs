using MediatR;

namespace FamousQuoteQuiz.Application.Features.User.Commands.UpdateUser;

public record UpdateUserCommand(int Id, string Firstname, string Lastname, string Username, string Email, bool IsActive) : IRequest<Unit>;

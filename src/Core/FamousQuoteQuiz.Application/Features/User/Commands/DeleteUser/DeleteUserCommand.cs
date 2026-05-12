using MediatR;

namespace FamousQuoteQuiz.Application.Features.User.Commands.DeleteUser;

public record DeleteUserCommand(int Id) : IRequest<Unit>;

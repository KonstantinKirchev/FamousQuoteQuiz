using MediatR;

namespace FamousQuoteQuiz.Application.Features.User.Commands.DisableUser;

public record DisableUserCommand(int Id) : IRequest<Unit>;

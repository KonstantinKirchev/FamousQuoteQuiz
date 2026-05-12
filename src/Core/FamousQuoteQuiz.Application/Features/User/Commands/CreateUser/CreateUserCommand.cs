using MediatR;

namespace FamousQuoteQuiz.Application.Features.User.Commands.CreateUser
{
    public record CreateUserCommand(string Firstname, string Lastname, string Username, string Email) : IRequest<Unit>;
}

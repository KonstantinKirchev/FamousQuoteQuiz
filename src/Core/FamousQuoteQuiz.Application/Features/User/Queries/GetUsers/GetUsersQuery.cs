using MediatR;

namespace FamousQuoteQuiz.Application.Features.User.Queries.GetUsers;

public class GetUsersQuery : IRequest<List<GetUserDto>>
{
    public bool IsLoggedInUser { get; set; }
}

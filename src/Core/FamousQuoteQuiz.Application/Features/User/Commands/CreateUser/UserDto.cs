

namespace FamousQuoteQuiz.Application.Features.User.Commands.CreateUser
{
    public class UserDto
    {
        public required string Email { get; set; }
        public required string Firstname { get; set; }
        public required string Lastname { get; set; }
        public required string UserName { get; set; }
    }
}

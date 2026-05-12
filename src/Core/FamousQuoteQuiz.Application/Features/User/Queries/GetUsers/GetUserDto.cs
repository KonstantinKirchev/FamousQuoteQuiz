using System;
using System.Collections.Generic;
using System.Text;

namespace FamousQuoteQuiz.Application.Features.User.Queries.GetUsers
{
    public class GetUserDto
    {
        public required string Email { get; set; }
        public required string Firstname { get; set; }
        public required string Lastname { get; set; }
        public required string UserName { get; set; }
    }
}

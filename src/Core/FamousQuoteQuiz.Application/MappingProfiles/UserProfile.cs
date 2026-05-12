using AutoMapper;
using FamousQuoteQuiz.Application.Features.User.Commands.CreateUser;
using FamousQuoteQuiz.Application.Features.User.Queries.GetUsers;
using FamousQuoteQuiz.Domain.Entities;

namespace FamousQuoteQuiz.Application.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<GetUserDto, User>().ReverseMap();
        }
    }
}

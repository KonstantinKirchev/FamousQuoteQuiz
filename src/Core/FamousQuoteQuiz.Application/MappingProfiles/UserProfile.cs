using AutoMapper;
using FamousQuoteQuiz.Application.Features.User.Commands.CreateUser;
using FamousQuoteQuiz.Domain.Entities;

namespace FamousQuoteQuiz.Application.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}

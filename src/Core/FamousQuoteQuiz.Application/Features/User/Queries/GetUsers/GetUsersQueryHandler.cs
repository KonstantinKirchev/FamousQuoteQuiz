using AutoMapper;
using FamousQuoteQuiz.Domain.Interfaces;
using MediatR;

namespace FamousQuoteQuiz.Application.Features.User.Queries.GetUsers;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<GetUserDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUsersQueryHandler(IUserRepository userRepository,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<List<GetUserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = new List<Domain.Entities.User>();
        var requests = new List<GetUserDto>();

        users = (List<Domain.Entities.User>) await _userRepository.GetAllAsync();
        requests = _mapper.Map<List<GetUserDto>>(users);

        return requests;
    }
}

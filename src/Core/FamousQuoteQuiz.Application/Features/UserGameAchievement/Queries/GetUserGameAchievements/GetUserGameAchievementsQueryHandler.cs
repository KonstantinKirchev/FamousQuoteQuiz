using AutoMapper;
using FamousQuoteQuiz.Application.Contracts.Persistence;
using FamousQuoteQuiz.Application.Features.Quote.Queries.GetQuotes;

namespace FamousQuoteQuiz.Application.Features.UserGameAchievement.Queries.GetUserGameAchievements
{
    public class GetUserGameAchievementsQueryHandler
    {
        private readonly IUserGameAchievementRepository _userGameAchievementRepository;
        private readonly IMapper _mapper;

        public GetUserGameAchievementsQueryHandler(IUserGameAchievementRepository userGameAchievementRepository,
            IMapper mapper)
        {
            _userGameAchievementRepository = userGameAchievementRepository;
            _mapper = mapper;
        }

        public async Task<List<UserGameAchievementDto>> Handle(GetQuotesQuery request, CancellationToken cancellationToken)
        {
            var userGameAchievement = new List<Domain.Entities.UserGameAchievement>();
            var requests = new List<UserGameAchievementDto>();

            userGameAchievement = (List<Domain.Entities.UserGameAchievement>)await _userGameAchievementRepository.GetAllAsync();
            requests = _mapper.Map<List<UserGameAchievementDto>>(userGameAchievement);

            return requests;
        }
    }
}

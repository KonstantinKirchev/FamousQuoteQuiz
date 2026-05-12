using FamousQuoteQuiz.Application.Contracts.Identity;
using FamousQuoteQuiz.Application.Models.Identity;
using FamousQuoteQuiz.Identity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace FamousQuoteQuiz.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public UserService(UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor)
        {
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }

        public string UserId { get => _contextAccessor.HttpContext?.User?.FindFirstValue("uid"); }

        public async Task<User> GetUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return new User
            {
                Email = user.Email,
                Id = user.Id,
                Firstname = user.Firstname,
                Lastname = user.Lastname
            };
        }

        public async Task<List<User>> GetUsers()
        {
            var users = await _userManager.GetUsersInRoleAsync("User");
            return users.Select(q => new User
            {
                Id = q.Id,
                Email = q.Email,
                Firstname = q.Firstname,
                Lastname = q.Lastname
            }).ToList();
        }
    }
}

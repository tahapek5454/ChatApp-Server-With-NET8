using ChatApp.API.Contexts;
using ChatApp.API.Models;
using ChatApp.API.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.API.Services
{
    public class UserService(ChatDbContext _dbContext) : IUserService
    {
        public async Task<int> AddUserAsync(UserVM userVM)
        {
            User user = new()
            {
                Email = userVM.Email,
                Password = userVM.Password,
                UserName = userVM.UserName,
            };

            await _dbContext.Users.AddAsync(user);

            await _dbContext.SaveChangesAsync();

            return user.Id;
        }

        public async Task<List<UserVM>> GetAllUserAsync()
            => await (_dbContext.Users.Select(x => new UserVM() { UserName = x.UserName, Email = x.Email })).ToListAsync();

        public async Task<UserVM> GetUserByIdAsync(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);

            UserVM userVM = new()
            {
                Email = user.Email,
                UserName = user.UserName,
            };

            return userVM;
        }
            
    }

    public interface IUserService
    {
        Task<int> AddUserAsync(UserVM userVM);
        Task<UserVM> GetUserByIdAsync(int id);
        Task<List<UserVM>> GetAllUserAsync();
    }
}

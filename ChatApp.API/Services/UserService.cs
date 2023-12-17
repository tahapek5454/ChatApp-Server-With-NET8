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

            var isExist = _dbContext.Users.Any(x => x.UserName == userVM.UserName);

            if (isExist)
                return -1;


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

        public async Task<UserVM> GetUserByUserName(string userName)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == userName);

            UserVM userVM = new()
            {
                Email = user?.Email ?? "",
                UserName = user?.UserName ?? "",
            };

            return userVM;
        }
            
    }

    public interface IUserService
    {
        Task<int> AddUserAsync(UserVM userVM);
        Task<UserVM> GetUserByUserName(string userName);
        Task<List<UserVM>> GetAllUserAsync();
    }
}

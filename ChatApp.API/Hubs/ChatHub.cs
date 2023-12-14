using ChatApp.API.Contexts;
using ChatApp.API.Models;
using ChatApp.API.ViewModels;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.API.Hubs
{
    public class ChatHub(ChatDbContext _dbContext): Hub
    {

        public async Task GetUserName(string userName)
        {
            var user = await _dbContext.Users.FirstAsync(x => x.UserName == userName);

            var client = await _dbContext.Clients.Include(x => x.User).FirstOrDefaultAsync(x => x.User.UserName == userName);

            if(client == null)
            {
                Client newClient = new Client()
                {
                    UserId = user.Id,
                    ConnectionId = Context.ConnectionId
                };

                await _dbContext.Clients.AddAsync(newClient);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                client.ConnectionId = Context.ConnectionId;
                _dbContext.Update(client);
                await _dbContext.SaveChangesAsync();
            }


            var users = await _dbContext.Users.Where(x => x.UserName != userName).Select(x => new UserVM()
            {
                Email = x.Email,
                UserName = x.UserName,
            }).ToListAsync();

            await Clients.All.SendAsync("clientJoined", userName);
            await Clients.Caller.SendAsync("users", users);
        }

        public async Task SendMessage(string to, string content)
        {
            var toUser = await _dbContext.Users.Include(u => u.Client).FirstAsync(x => x.UserName == to);
            var fromUser = await _dbContext.Users.Include(u => u.Client).FirstAsync(x => x.Client.ConnectionId == Context.ConnectionId);

            Message message = new Message()
            {
                Content = content,
                From = fromUser.UserName,
                To = toUser.UserName
            };

            await _dbContext.Messages.AddAsync(message);
            await _dbContext.SaveChangesAsync();

            await Clients.Clients(toUser.Client.ConnectionId).SendAsync("receiveMessage", content, fromUser.UserName);
        }
    }
}

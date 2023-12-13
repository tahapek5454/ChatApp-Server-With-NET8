using ChatApp.API.Contexts;
using ChatApp.API.Models;
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

            await Clients.All.SendAsync("clientJoined", userName);
        }
    }
}

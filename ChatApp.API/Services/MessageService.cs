using ChatApp.API.Contexts;
using ChatApp.API.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.API.Services
{
    public class MessageService(ChatDbContext _dbContext) : IMessageService
    {
        public async Task<List<MessageVM>> GetMessagesAsync(string from, string to)
        {

            var messages = await _dbContext.Messages
                .Where(m => (m.From == from && m.To == to) || (m.From == to && m.To == from))
                .OrderBy(m => m.Id)
                .Select(x => new MessageVM()
                {
                    From = x.From,
                    Message = x.Content,
                    To = x.To,
                })
                .ToListAsync();

            return messages;
        }
    }

    public interface IMessageService
    {
        Task<List<MessageVM>> GetMessagesAsync(string from, string to);
    }
}

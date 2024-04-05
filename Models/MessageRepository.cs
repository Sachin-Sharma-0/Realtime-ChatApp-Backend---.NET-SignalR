using ChatApp.Data;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Models
{
    // Message repository interface
    public interface IMessageRepository
    {
        Task SaveMessageAsync(Message message);
        Task<List<Message>> GetMessageHistoryAsync(string userId);
    }
    // Message repository implementation
    public class MessageRepository : IMessageRepository
    {
        private readonly ApplicationDbContext _context;

        public MessageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveMessageAsync(Message message)
        {
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Message>> GetMessageHistoryAsync(string userId)
        {
            return await _context.Messages
                .Where(m => m.ReceiverId.ToString() == userId)
                .OrderByDescending(m => m.Timestamp)
                .ToListAsync();
        }
    }
}

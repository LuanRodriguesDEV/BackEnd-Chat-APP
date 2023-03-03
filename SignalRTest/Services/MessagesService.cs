using SignalRTest.Context;
using SignalRTest.Model;
using System.Data;


namespace SignalRTest.Services
{
    public class MessagesService
    {
        private readonly AppDbContext _context;

        public MessagesService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Messages> Create(Messages message)
        {
            try
            {
                await _context.Messages.AddAsync(message);
                await _context.SaveChangesAsync();
                return message;
            }catch(DBConcurrencyException ex)
            {
                return null;
            }
        }
    }
}

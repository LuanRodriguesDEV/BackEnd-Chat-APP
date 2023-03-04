using Microsoft.AspNetCore.SignalR;
using SignalRTest.Context;
using SignalRTest.DTOS;
using SignalRTest.Hubs;
using SignalRTest.Model;
using System.Data;


namespace SignalRTest.Services
{
    public class MessagesService
    {
        private readonly AppDbContext _context;
        private readonly IHubContext<ChatHub> _hubContext;

        public MessagesService(AppDbContext context, IHubContext<ChatHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }
        public async Task<Messages> Create(MessageDTO message)
        {
            try
            {
                await _context.Messages.AddAsync(message.Message);
                await _context.SaveChangesAsync();
                try
                {
                    await _hubContext.Clients.Group(message.To.ToString()).SendAsync("ReceiveMessage", message.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                
                return message.Message;
            }catch(DBConcurrencyException ex)
            {
                return null;
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using SignalRTest.Context;
using SignalRTest.DTOS;
using SignalRTest.Model;
using System.Data;




namespace SignalRTest.Services
{
    public class ChatServices
    {
        private readonly AppDbContext _context;

        public ChatServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task <ChatDTO> Create(Chat chat,int id)
        {
            try
            {
                await _context.Chats.AddAsync(chat);
                await _context.SaveChangesAsync();
                
                var get = await _context.Chats
                .Include(m => m.Messages)
                .Include(c => c.ChatPeoples).ThenInclude(u => u.User)
                .Where(x => x.Id == chat.Id).FirstOrDefaultAsync();

                var getUser = get.ChatPeoples.FirstOrDefault(x => x.UserId != id);
                var NewDTO = new ChatDTO
                {
                    Id = get.Id,
                    Messages = get.Messages,
                    UserId = getUser.UserId,
                    Name = getUser.User.Name,
                    Online = getUser.User.IsOnline,
                    Profile = getUser.User.Profile,
                    Typing = false
                };


                return NewDTO;
            }
            catch (DBConcurrencyException ex)
            {
                return null;
            }
        }
        public async Task <List<ChatDTO>> GetMyChats(int id)
        {
            var get = await _context.Chats
                .Include(m => m.Messages)
                .Include(c => c.ChatPeoples).ThenInclude(u => u.User)
                .Where(c => c.ChatPeoples.Any(r => r.UserId == id))
                .ToListAsync();

            var ListDTO = new List<ChatDTO>();

            foreach (var chat in get)
            {   
                var getUser = chat.ChatPeoples.FirstOrDefault(x => x.UserId != id);
                var NewDTO = new ChatDTO
                {
                    Id = chat.Id,
                    Messages = chat.Messages,
                    UserId = getUser.UserId,
                    Name = getUser.User.Name,
                    Online = getUser.User.IsOnline,
                    Profile = getUser.User.Profile,
                    Typing = false
                };
                ListDTO.Add(NewDTO);
            }
            return ListDTO;
        }
    }
}

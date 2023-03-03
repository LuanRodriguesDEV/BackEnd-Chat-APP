using Microsoft.EntityFrameworkCore;
using SignalRTest.Model;

namespace SignalRTest.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatPeoples> ChatPeoples { get; set; }
        public DbSet<Messages> Messages { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using SignalRTest.Context;
using SignalRTest.Model;
using System.Data;

namespace SignalRTest.Services
{
    public class UserServices
    {
        private readonly AppDbContext _context;

        public UserServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> CreateUser(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch(DBConcurrencyException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<User?> Login(string email,string password)
        {
            try
            {
                return await _context.Users.Where(x => x.Email == email && x.Password == password).FirstOrDefaultAsync();
            }
            catch (DBConcurrencyException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<List<User>>? GetAllUsers()
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch (DBConcurrencyException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}

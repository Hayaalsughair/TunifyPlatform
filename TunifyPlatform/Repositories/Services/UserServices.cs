using Microsoft.EntityFrameworkCore;
using TunifyPlatform.Data;
using TunifyPlatform.Models;
using TunifyPlatform.Repositories.Interfaces;

namespace TunifyPlatform.Repositories.Services
{
    public class UserServices : IUser
    {
        private readonly TunifyDbContext _context;

        public UserServices(TunifyDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUser(User user)
        {
            _context.users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUser(int id)
        {
            var getUser = await GetUserById(id);
            _context.users.Remove(getUser);
            await _context.SaveChangesAsync();

        }

        public async Task<List<User>> GetAllUsers()
        {
            var allUsers = await _context.users.ToListAsync();
            return allUsers;
        }

        public async Task<User> GetUserById(int userId)
        {
            var specificUser = await _context.users.FindAsync(userId);
            return specificUser;
        }

        public async Task<User> UpdateUser(int userId, User user)
        {
            var exsitingUser = await _context.users.FindAsync(userId);
            exsitingUser = user;
            await _context.SaveChangesAsync();
            return user;
        }
    }
}

using CashTrack.Application.Interfaces;
using CashTrack.Domain.Entities;
using CashTrack.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CashTrack.Infrastructure.Repositories
{
    // Handles database operations for users
    public class UserRepository : IUserRepository
    {
        private readonly CashTrackDbContext _context;

        public UserRepository(CashTrackDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task CreateAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
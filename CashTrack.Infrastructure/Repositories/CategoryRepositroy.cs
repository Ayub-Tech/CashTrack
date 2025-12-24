using CashTrack.Application.Interfaces;
using CashTrack.Domain.Entities;
using CashTrack.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CashTrack.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CashTrackDbContext _context;

        public CategoryRepository(CashTrackDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task CreateAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Category category)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}
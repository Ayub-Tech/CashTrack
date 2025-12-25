using CashTrack.Application.Interfaces;
using CashTrack.Domain.Entities;
using CashTrack.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CashTrack.Infrastructure.Repositories
{
    // Handles database operations for transactions
    public class TransactionRepository : ITransactionRepository
    {
        private readonly CashTrackDbContext _context;

        public TransactionRepository(CashTrackDbContext context)
        {
            _context = context;
        }

        // Get all transactions from database
        public async Task<List<Transaction>> GetAllAsync()
        {
            return await _context.Transactions.ToListAsync();
        }

        // Get single transaction by ID
        public async Task<Transaction?> GetByIdAsync(int id)
        {
            return await _context.Transactions.FindAsync(id);
        }

        // Add new transaction to database
        public async Task CreateAsync(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
        }

        // Update existing transaction
        public async Task UpdateAsync(Transaction transaction)
        {
            _context.Transactions.Update(transaction);
            await _context.SaveChangesAsync();
        }

        // Remove transaction from database
        public async Task DeleteAsync(Transaction transaction)
        {
            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
        }
    }
}
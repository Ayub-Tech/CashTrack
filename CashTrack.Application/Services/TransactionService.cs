using CashTrack.Application.DTOs;
using CashTrack.Application.Interfaces;
using CashTrack.Domain.Entities;

namespace CashTrack.Application.Services
{
    // Business logic layer for transaction operations
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _repository;

        public TransactionService(ITransactionRepository repository)
        {
            _repository = repository;
        }

        // Retrieve all transactions and convert to DTOs
        public async Task<IEnumerable<TransactionDto>> GetAllAsync()
        {
            var transactions = await _repository.GetAllAsync();

            return transactions.Select(t => new TransactionDto
            {
                Id = t.Id,
                Amount = t.Amount,
                Date = t.Date,
                UserId = t.UserId,
                CategoryId = t.CategoryId
            });
        }

        // Get single transaction by ID
        public async Task<TransactionDto?> GetByIdAsync(int id)
        {
            var transaction = await _repository.GetByIdAsync(id);

            if (transaction == null)
                return null;

            return new TransactionDto
            {
                Id = transaction.Id,
                Amount = transaction.Amount,
                Date = transaction.Date,
                UserId = transaction.UserId,
                CategoryId = transaction.CategoryId
            };
        }

        // Create new transaction from DTO
        public async Task<TransactionDto> CreateAsync(CreateTransactionDto createDto)
        {
            var transaction = new Transaction
            {
                Amount = createDto.Amount,
                Date = createDto.Date,
                UserId = createDto.UserId,
                CategoryId = createDto.CategoryId
            };

            await _repository.CreateAsync(transaction);

            return new TransactionDto
            {
                Id = transaction.Id,
                Amount = transaction.Amount,
                Date = transaction.Date,
                UserId = transaction.UserId,
                CategoryId = transaction.CategoryId
            };
        }

        // Update existing transaction
        public async Task<TransactionDto?> UpdateAsync(int id, CreateTransactionDto updateDto)
        {
            var transaction = await _repository.GetByIdAsync(id);

            if (transaction == null)
                return null;

            transaction.Amount = updateDto.Amount;
            transaction.Date = updateDto.Date;
            transaction.UserId = updateDto.UserId;
            transaction.CategoryId = updateDto.CategoryId;

            await _repository.UpdateAsync(transaction);

            return new TransactionDto
            {
                Id = transaction.Id,
                Amount = transaction.Amount,
                Date = transaction.Date,
                UserId = transaction.UserId,
                CategoryId = transaction.CategoryId
            };
        }

        // Delete transaction by ID
        public async Task<bool> DeleteAsync(int id)
        {
            var transaction = await _repository.GetByIdAsync(id);

            if (transaction == null)
                return false;

            await _repository.DeleteAsync(transaction);
            return true;
        }
    }
}
using CashTrack.Application.DTOs;

namespace CashTrack.Application.Interfaces
{
    // Contract defining what operations the Transaction service must provide
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionDto>> GetAllAsync();
        Task<TransactionDto?> GetByIdAsync(int id);
        Task<TransactionDto> CreateAsync(CreateTransactionDto createDto);
        Task<TransactionDto?> UpdateAsync(int id, CreateTransactionDto updateDto);
        Task<bool> DeleteAsync(int id);
    }
}
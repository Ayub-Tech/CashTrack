using CashTrack.Application.DTOs;
using System.Collections.Generic;

namespace CashTrack.Application.Interfaces
{
    // Interface for transaction-related business logic
    public interface ITransactionService
    {
        // Returns all transactions
        List<TransactionDto> GetAll();

        // Returns a single transaction by id
        TransactionDto GetById(int id);

        // Creates a new transaction
        void Create(TransactionDto dto);

        // Updates an existing transaction
        bool Update(int id, TransactionDto dto);

        // Deletes a transaction
        bool Delete(int id);
    }
}
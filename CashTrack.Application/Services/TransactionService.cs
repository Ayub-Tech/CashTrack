using CashTrack.Application.DTOs;
using CashTrack.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CashTrack.Application.Services
{
    // Service responsible for transaction-related business logic
    public class TransactionService : ITransactionService
    {
        // Temporary in-memory storage (will be replaced by database later)
        private static readonly List<TransactionDto> _transactions = new()
        {
            new TransactionDto
            {
                Id = 1,
                Amount = 100,
                Date = DateTime.Now.AddDays(-2),
                UserId = 1,
                CategoryId = 1
            },
            new TransactionDto
            {
                Id = 2,
                Amount = 250,
                Date = DateTime.Now.AddDays(-1),
                UserId = 1,
                CategoryId = 2
            }
        };

        // Returns all transactions
        public List<TransactionDto> GetAll()
        {
            return _transactions;
        }

        // Returns a single transaction by id
        public TransactionDto GetById(int id)
        {
            return _transactions.FirstOrDefault(t => t.Id == id);
        }

        // Creates a new transaction
        public void Create(TransactionDto dto)
        {
            dto.Id = _transactions.Any()
                ? _transactions.Max(t => t.Id) + 1
                : 1;

            _transactions.Add(dto);
        }

        // Updates an existing transaction
        public bool Update(int id, TransactionDto dto)
        {
            var existing = _transactions.FirstOrDefault(t => t.Id == id);
            if (existing == null)
                return false;

            existing.Amount = dto.Amount;
            existing.Date = dto.Date;
            existing.UserId = dto.UserId;
            existing.CategoryId = dto.CategoryId;

            return true;
        }

        // Deletes a transaction
        public bool Delete(int id)
        {
            var transaction = _transactions.FirstOrDefault(t => t.Id == id);
            if (transaction == null)
                return false;

            _transactions.Remove(transaction);
            return true;
        }
    }
}
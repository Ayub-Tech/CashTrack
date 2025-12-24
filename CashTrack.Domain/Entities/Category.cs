using System.Collections.Generic;

namespace CashTrack.Domain.Entities
{
    // Represents a transaction category (e.g. Food, Transport)
    public class Category
    {
        // Primary key
        public int Id { get; set; }

        // Category name
        public string Name { get; set; }

        // Navigation property: one category -> many transactions
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
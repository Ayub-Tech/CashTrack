using System;
using System.Collections.Generic;

namespace CashTrack.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // Navigation property: One user can have many transactions
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
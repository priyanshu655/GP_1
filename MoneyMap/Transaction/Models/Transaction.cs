using System;

namespace GP_1.Models
{
    public class Transaction
    {
        public long TransactionId { get; set; }

        public int UserId { get; set; }

        public int CategoryId { get; set; }

        public DateTime TransactionDate { get; set; }

        public string Description { get; set; } = string.Empty;

        public decimal Amount { get; set; }

        public DateTime CreatedAt { get; set; }

        public string TransactionType { get; set; } = string.Empty;

        public string CategoryName { get; set; } = string.Empty;
    }
}

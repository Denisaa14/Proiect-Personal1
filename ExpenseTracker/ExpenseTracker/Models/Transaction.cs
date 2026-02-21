using System.ComponentModel.DataAnnotations;
namespace ExpenseTracker.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; }
        public string Type { get; set; } 
        public DateTime Date { get; set; } = DateTime.Now;

        public string? UserId { get; set; }

    }
}

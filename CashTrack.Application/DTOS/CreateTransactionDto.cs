namespace CashTrack.Application.DTOs
{
    public class CreateTransactionDto
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
    }
}
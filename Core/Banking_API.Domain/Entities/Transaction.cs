using Banking_API.Domain.Entities.Common;

namespace Banking_API.Domain.Entities
{
    public class Transaction:BaseEntity
    {
        public decimal Amount { get; set; } 
        public string TransactionType { get; set; } 
        public string Description { get; set; } 
        public Guid AccountId { get; set; } 
        public Account Account { get; set; }
    }
}

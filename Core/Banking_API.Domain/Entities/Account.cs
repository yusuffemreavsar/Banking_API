using Banking_API.Domain.Entities.Common;

namespace Banking_API.Domain.Entities
{
    public class Account:BaseEntity
    {
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; } 
        public Guid CustomerId { get; set; }    
        public Customer Customer { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}

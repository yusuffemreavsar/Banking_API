namespace Banking_API.Domain.Entities.Common
{
    public interface IBaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTime UpdatedDate { get; set;}

    }
}

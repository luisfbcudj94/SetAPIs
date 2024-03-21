namespace API.Application.Contracts.DTOs
{
    public class TagDTO
    {
        public virtual Guid Id { get; set; }
        public virtual int Name { get; set; }
        public virtual int Value { get; set; }
    }
}

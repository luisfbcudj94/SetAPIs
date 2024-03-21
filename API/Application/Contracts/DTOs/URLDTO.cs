namespace API.Application.Contracts.DTOs
{
    public class URLDTO
    {
        public virtual Guid Id { get; set; }
        public virtual Guid? HTTPMethodId { get; set; }
        public virtual string? Value { get; set; }
    }
}

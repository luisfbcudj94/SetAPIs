namespace API.Domain.Models
{
    public class APIType
    {
        public APIType()
        {
            Id = Guid.NewGuid();
        }
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
    }
}

namespace API.Domain.Models
{
    public class Tag
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Value { get; set; }
    }
}

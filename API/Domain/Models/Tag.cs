namespace API.Domain.Models
{
    public class Tag
    {
        public virtual Guid Id { get; set; }
        public virtual int Name { get; set; }
        public virtual int Value { get; set; }
    }
}
